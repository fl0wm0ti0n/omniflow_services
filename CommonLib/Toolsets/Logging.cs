using Serilog;
using Serilog.Events;
using System;
using System.Globalization;

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

            // Read Logpath from Appsettings
            var _logPath = AppConfig.ReadSetting<string>("Generic_LogPath");

            // Read LogToCOnsole or Not from Appsettings
            var _logToConsole = AppConfig.ReadSetting<string>("Generic_LogToConsole");

            try
            {
                // With or without console Logging
                if (_logToConsole == "true")
                {
                    Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@_logPath + "NodeMonit_Log_" + thatDate + ".log")
                            .WriteTo.Console()
                            .CreateLogger();
                }
                else
                {
                    Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@"tmp/NodeMonit_Log_" + thatDate + ".log")
                            .CreateLogger();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong by creating Logger, {0}", e);
            }
            finally
            {

            }

        }
    }
}