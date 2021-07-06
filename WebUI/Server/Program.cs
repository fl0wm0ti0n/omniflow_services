using CommonLib.Toolsets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Serilog;

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
                CreateHostBuilder(args).Build().Run();
                Log.Information("... success");
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting the Webserver");
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Listen(GetKestrelIp(), GetKestrelPort(),
                            listenOptions =>
                            {
                                if (AppConfig.ReadSetting<bool>("Blazor_HttpsOn"))
                                {
                                    Log.Information("HTTPS is on");
                                    // Tutorial cert: https://thegreenerman.medium.com/set-up-https-on-local-with-net-core-and-docker-7a41f030fc76
                                    // Tutorial compose: https://docs.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-5.0
                                    // Tutorial HTTPS: https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio
                                    // Ways to set Urls: https://andrewlock.net/5-ways-to-set-the-urls-for-an-aspnetcore-app/
                                    // certspeicher leeren:     dotnet dev-certs https --clean
                                    // neues cert für die App:  dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\webui.server.pfx -p eistee
                                    // 
                                    var certpath = AppConfig.ReadSetting<string>("Blazor_CertPath");
                                    var certpw = AppConfig.ReadSetting<string>("Blazor_CertPw");
                                    Log.Information("HTTPS Certificate = {0} \n HTTPS Certificate Password = {1}", certpath, certpw);
                                    listenOptions.UseHttps(certpath, certpw);
                                }
                                else
                                {
                                    Log.Information("HTTPS is off");
                                }
                            });
                    });
                    webBuilder.UseStartup<Startup>();
                });


        public static IPAddress GetKestrelIp()
        {
            string ip = AppConfig.ReadSetting<string>("Blazor_Ip");
            if (ip.Length > 1)
            {
                Log.Information("Kestrel Ip = {0}", ip);
                return IPAddress.Parse(ip);
            }
            Log.Information("no configured Kestrel Ip, Default Ip = loopback");
            return IPAddress.Loopback;
        }

        public static int GetKestrelPort()
        {
            int port = AppConfig.ReadSetting<int>("Blazor_Port");
            if (port > 1)
            {
                Log.Information("Kestrel Port = {0}", port);
                return port;
            }
            Log.Information("no configured Kestrel Port, Default Port = 80");
            return 80;
        }
    }
}
