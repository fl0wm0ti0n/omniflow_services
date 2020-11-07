using DatabaseLib.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using NodeMonitor.Business;
using NodeMonitor.Test;
using NodeMonitor.Default;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using NodeMonitor.Models;
using System.Net;
using NodeMonitor.Controller;
using AutoMapper;

namespace NodeMonitor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var context = new nmDBContext();
            var dbcontr = new DatabaseController();

            // Build Logger
            Logging logger = new Logging();
            logger.BuildLog();


            // Check DB Connection and migrate if necessary
            try
            {
                Log.Information("Check DB Connection ...");
                if (dbcontr.CheckConnection())
                {
                    Log.Information("... success");
                    Log.Information("Add Migration or Create DB ...");
                    await context.Database.MigrateAsync();
                }
                else
                {
                    Log.Fatal("There was a problem connecting the DB");
                };
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem adding the migration or Creating the DB");
                Log.CloseAndFlush();
                return;
            }

            // Check DB connection and start test with testdata
            try
            {
                Log.Information("Check DB Connection ...");
                if (dbcontr.CheckConnection())
                {
                    Log.Information("... success");

                    // starte Debugtest
                    Testdata.CreateTestdata();
                    CreateDefaultTableValues.CreateData();
                    ThreefoldApiUriEntity NodesUri = null;
                    ThreefoldApiUriEntity FarmsUri = null;
                    Log.Information("Test getting Nodes and Farms via threefoldApi and save them into DB");
                    NodesUri = context.ThreefoldApiUris.Single(n => n.Name == "AllNodes");
                    FarmsUri = context.ThreefoldApiUris.Single(n => n.Name == "AllFarms");
                    JsonToEntity.AddFarmList(DeserealizeJson.CheckUriForFarmListAndGetJson(FarmsUri));
                    JsonToEntity.AddNodeList(DeserealizeJson.CheckUriForNodeListAndGetJson(NodesUri));
                }
                else
                {
                    Log.Fatal("There was a problem connecting the DB");
                };

            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem with the testrun");
                Log.CloseAndFlush();
                return;
            }

            // Start all Services
            try
            {
                Log.Information("Starting up the services");

                if (AppConfig.ReadSetting("SignalR_ServerIp") == "localhost")
                {
                    Log.Information(" bind to Ip {0}", "localhost");
                }
                else
                {
                    Log.Information(" bind to Ip {0}", IPAddress.Parse(AppConfig.ReadSetting("SignalR_ServerIp")));
                }
                Log.Information(" bind to Port {0}", Int32.Parse(AppConfig.ReadSetting("SignalR_ServerPort")));
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting the services");
                Log.CloseAndFlush();
                return;
            }
        }

        //  Bootup
        // 1. Datenbank Anlegen
        // 2. Generate ServiceID (in DB oder Reg)
        // 3. Settings aus DB laden

        //  Running
        // 4. Tasks abarbeiten
        //        -> von Settings oder von SchedulesEntity
        // 5. SignalR anfragen bearbeiten

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            // Unter Linux:
            .UseSystemd()
            // Unter Windows:
            //.UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();
            })
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                string address = AppConfig.ReadSetting("SignalR_ServerIp");
                string port = AppConfig.ReadSetting("SignalR_ServerPort");
                string httpsOn = AppConfig.ReadSetting("SignalR_HttpsOn");
                string url = "http://" + address + ":" + port;
                if (httpsOn == "true")
                {
                    url = "https://" + address + ":" + port;
                }

                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls(url);
                //webBuilder.UseKestrel(opts =>
                //{
                //    if (AppConfig.ReadSetting("SignalR_ServerIp") == "localhost")
                //    {
                //        Log.Information(" bind to Ip {0}", "localhost");
                //        //opts.ListenLocalhost(Int32.Parse(AppConfig.ReadSetting("SignalR_ServerPort")));
                //        opts.Listen(IPAddress.Loopback, Int32.Parse(AppConfig.ReadSetting("SignalR_ServerPort")));
                //    }
                //    else
                //    {
                //        Log.Information(" bind to Ip {0}", IPAddress.Parse(AppConfig.ReadSetting("SignalR_ServerIp")));
                //        opts.Listen(IPAddress.Parse(AppConfig.ReadSetting("SignalR_ServerIp")), Int32.Parse(AppConfig.ReadSetting("SignalR_ServerPort")));
                //    };
                //});
            });
        }
    }
}