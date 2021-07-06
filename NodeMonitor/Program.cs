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
using CommonLib.Toolsets;
using DatabaseLib.Entities.NodeMonEntities;
using NodeMonitor.API.Client;

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


            // read out settings for retry connection to db
            int dbConnectretryNumber = AppConfig.ReadSetting<int>("Database_ConnectRetryNumber");
            int dbConnectretryGap = AppConfig.ReadSetting<int>("Database_ConnectRetryGapInSeconds");
            // Check DB Connection and migrate if necessary
            try
            {
                //await context.Database.EnsureCreatedAsync();
                Log.Information("Check if DB already exist, else add Migration or Create DB ...");
                await context.Database.MigrateAsync();
                Log.Information("Check DB Connection ...");
                if (dbcontr.CheckConnection(context))
                {
                    Log.Information("... success");
                }
                else
                {
                    Log.Fatal("There was a problem connecting the DB");
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem adding the migration or Creating the DB");
                var count = 0;
                do
                {
                    Log.Information(e, "Try again to connect to the DB each {1} seconds for {2} times",dbConnectretryGap, dbConnectretryNumber);
                    System.Threading.Thread.Sleep(dbConnectretryGap * 1000);
                    await context.Database.MigrateAsync();
                    count++;
                } while (count <= dbConnectretryNumber);

                count = 0;
                Log.CloseAndFlush();
                return;
            }


            // Start all Services
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting the services");
                Log.CloseAndFlush();
                return;
            }

            // Check DB connection and start test with testdata
            try

            {
                Log.Information("Check DB Connection ...");
                if (dbcontr.CheckConnection(context))
                {
                    Log.Information("... success");
                    TFPublicEntityController _tfPublicEntityController = new TFPublicEntityController();
                    TFPublicWebApiClientController _tfPublicWebApiClientController = new TFPublicWebApiClientController(new ThreefoldPublicApiClient());
                    // starte Debugtest
                    Testdata.CreateTestdata();
                    CreateDefaultTableValues.CreateData();
                    ThreefoldApiUriEntity NodesUri = null;
                    ThreefoldApiUriEntity FarmsUri = null;
                    Log.Information("Test getting Nodes and Farms via threefoldApi and save them into DB");
                    NodesUri = context.ThreefoldApiUris.Single(n => n.Name == "AllNodes");
                    FarmsUri = context.ThreefoldApiUris.Single(n => n.Name == "AllFarms");
                    _tfPublicEntityController.AddFarmList(_tfPublicWebApiClientController.GetFarmListAsync().Result);
                    _tfPublicEntityController.AddNodeList(_tfPublicWebApiClientController.GetNodeListAsync().Result);
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
                //webBuilder.UseUrls(grpcUri);
                webBuilder.UseStartup<Startup>();

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