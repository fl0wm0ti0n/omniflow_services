using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.Collection;
using AutoMapper.EquivalencyExpression;
using AutoMapper.EntityFrameworkCore;

using Serilog;
using Serilog.Events;

using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;

using NodeMonitor.Business;
using NodeMonitor.Test;

namespace NodeMonitor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"tmp/NodeMonit_Log.log")
                .CreateLogger();
            // … other setups removed for clarity

            // initialize Automapper EFCore
            //var services = new ServiceCollection();
            //services.AddDbContext<nmDBContext>();
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddAutoMapper((serviceProvider, automapper) =>
            //{
            //    automapper.AddCollectionMappers();
            //    automapper.UseEntityFrameworkCoreModel<nmDBContext>(serviceProvider);
            //}, typeof(nmDBContext).Assembly);
            //var serviceProvider = services.BuildServiceProvider();

            //var services = new ServiceCollection();
            //services.AddDbContext<nmDBContext>();
            //var serviceProvider = services.BuildServiceProvider();

            try
            {
                var context = new nmDBContext();
                await context.Database.MigrateAsync();

                Log.Information("Check DB Connection ...");
                var dbcontr = new DatabaseController();

                if (dbcontr.CheckConnection())
                {
                    Log.Information("... success");
                    // starte Debugtest

                    Testdata.CreateTestdata();
                    ThreefoldApiUriEntity NodesUri = null;
                    ThreefoldApiUriEntity FarmsUri = null;
                    NodesUri = context.ThreefoldApiUris
                            .Single(n => n.Name == "AllNodes");

                    FarmsUri = context.ThreefoldApiUris
                                        .Single(n => n.Name == "AllFarms");

                    foreach(var item in DeserealizeJson.CheckUriForFarmListAndGetJson(FarmsUri))
                    {
                        JsonToEntity.AddFarm(item);
                    };

                    foreach (var item in DeserealizeJson.CheckUriForNodeListAndGetJson(NodesUri))
                    {
                        JsonToEntity.AddNode(item);
                    };

                }
                else
                {
                    Log.Fatal("Datenbank kann nicht erreicht werden");
                };

                Log.Information("Starting up the service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting the service");
                return;
            }
            finally
            {
                Testdata.DeleteTestdata();
                Log.CloseAndFlush();
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
                .UseSerilog();
        }
    }
}