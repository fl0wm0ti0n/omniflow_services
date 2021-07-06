using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Serilog;

namespace CommonLib.Toolsets
{
    public class AppConfig
    {
        enum AppSettings
        {
            WebUiInstallPath    = 1,
            SignalRHttpsOn      = 21,
            SignalRClientIp     = 22,
            SignalRClientPort   = 23,
            SignalRServerIp     = 24,
            SignalRServerPort   = 25,
        }

        public static Dictionary<string,string> ReadAllSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                Dictionary<string, string> settingDict = new Dictionary<string, string>();

                if (appSettings.Count == 0)
                {
                    Log.Warning("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        settingDict.Add(key, appSettings[key]);
                    }
                }
                return settingDict;
            }
            catch (ConfigurationErrorsException e)
            {
                Log.Warning(e,"Error reading app settings");
                return null;
            }
        }

        public static T ReadSetting<T>(string key, T defaultValue = default(T)) where T : IConvertible
        {
            try
            {
                string setting = ConfigurationManager.AppSettings[key] ?? "";

                T result = defaultValue;
                if (!string.IsNullOrEmpty(setting))
                {
                    T typeDefault = default(T);
                    if (typeof(T) == typeof(String))
                    {
                        typeDefault = (T)(object)String.Empty;
                    }
                    result = (T)Convert.ChangeType(setting, typeDefault.GetTypeCode());
                }
                return result;
            }
            catch (Exception e)
            {
                Log.Warning(e,"Error reading app settings");
                return (T)(object)null;
            }
        }

        public static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException e)
            {
                Log.Warning(e,"Error writing app settings");
            }
        }
    }
}