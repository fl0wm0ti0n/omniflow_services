using NodeMonitor.Business;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeMonitor.API.SignalR
{
    public class SignalRServer
    {
        public void StartServer()
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx 
            // for more information.
            //try
            //{
            //    string address = AppConfig.ReadSetting("SignalR_ServerIp");
            //    string port = AppConfig.ReadSetting("SignalR_ServerPort");
            //    string httpsOn = AppConfig.ReadSetting("SignalR_HttpsOn");
            //    string url = "http://" + address + ":" + port;
            //    if (httpsOn == "true")
            //    {
            //        url = "https://" + address + ":" + port;
            //    }
            //    //WebApp.Start<Startup>(url);
            //    using (WebApp.Start(url))
            //    {
            //        Log.Information("Server running on {0}", url);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Log.Error("Something went wrong by creating SignalR-Server, {0}", e);
            //}
            //finally
            //{
            //
            //}

        }
    }
}