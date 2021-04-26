using CommonLib.Toolsets;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace WebUI.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logging logger = new Logging();
            logger.BuildLog();

            try
            {
                Log.Information("Startup Webserver ...");
                CreateHostBuilder(args);
                BuildWebHost(args).Run();
                Log.Information("... success");
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting the Webserver");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            //.UseSystemd()
            .UseSerilog();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}