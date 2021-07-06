using Serilog;
using Serilog.Events;
using System;
using System.Globalization;
using Serilog.Core;

namespace CommonLib.Toolsets
{
    public class Logging
    {
        public void BuildLog()
        {
            // DateTime configuration for Logging
            DateTimeOffset thisDate = DateTimeOffset.Now;
            CultureInfo culture = new CultureInfo("de-DE");
            var thatDate = thisDate.ToString("O", culture);
            var levelSwitch = new LoggingLevelSwitch();
            // Read Logpath from Appsettings
            var logPath = AppConfig.ReadSetting<string>("Generic_LogPath");

            // Read LogToCOnsole or Not from Appsettings
            var logToConsole = AppConfig.ReadSetting<bool>("Generic_LogToConsole");
            
            // Read LogMicroservice or Not from Appsettings
            var logName = AppConfig.ReadSetting<string>("Generic_LogMicroservice");
            
            // Read LogMicroservice or Not from Appsettings
            var logLevel = AppConfig.ReadSetting<string>("Generic_LogLevel");

            try
            {
                // With or without console Logging
                if (logToConsole)
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .Enrich.FromLogContext()
                        .WriteTo.File(logPath + logName + "_" + thatDate + ".log")
                        .WriteTo.Console()
                        .CreateLogger();
                }
                else
                {
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .Enrich.FromLogContext()
                        .WriteTo.File(logPath + logName + "_" + thatDate + ".log")
                        .CreateLogger();
                }

                switch (logLevel)
                {
                    case "debug":
                        levelSwitch.MinimumLevel = LogEventLevel.Debug;
                        break;
                    case "warning":
                        levelSwitch.MinimumLevel = LogEventLevel.Warning;
                        break;
                    case "error":
                        levelSwitch.MinimumLevel = LogEventLevel.Error;
                        break;
                    case "fatal":
                        levelSwitch.MinimumLevel = LogEventLevel.Fatal;
                        break;
                    case "verbose":
                        levelSwitch.MinimumLevel = LogEventLevel.Verbose;
                        break;
                    case "information":
                        levelSwitch.MinimumLevel = LogEventLevel.Information;
                        break;
                    default:
                        levelSwitch.MinimumLevel = LogEventLevel.Information;
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong by creating Logger, {0}", e);
            }
        }
    }
}