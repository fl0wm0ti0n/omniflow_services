using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CommonLib.Toolsets;
using Serilog;

namespace NodeMonitor.API.Client
{
    public class ApiClientBase : IApiClientBase
    {
        protected HttpClient Client;
        protected Uri ClientUri;
        protected string ClientPort;
        public ApiClientBase()
        {
            try
            {
                Client = new HttpClient();
                ClientPort = AppConfig.ReadSetting<string>("WebApiClient_TargetPort");
                var rawUri = new Uri(AppConfig.ReadSetting<string>("WebApiClient_TargetIp"));
                if (AppConfig.ReadSetting<bool>("WebApiClient_HttpsOn"))
                {
                    if (CheckUri($"https://{rawUri}:{ClientPort}/"))
                    {
                        ClientUri = new Uri($"https://{rawUri}:{ClientPort}/");
                    }
                }
                else
                {
                    if (CheckUri($"http://{rawUri}:{ClientPort}/"))
                    {
                        ClientUri = new Uri($"http://{rawUri}:{ClientPort}/");
                    }
                }

                Client.BaseAddress = ClientUri;
                Client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
                Client.DefaultRequestVersion = HttpVersion.Version20;
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception e)
            {
                Log.Error("Exception creating ApiClient",e);
                throw;
            }
        }
        private static bool CheckUri(string UriString)
        {
            Uri outUri;
            if (Uri.TryCreate(UriString, UriKind.Absolute, out outUri) && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
            {
                return true;
            }
            else
            {
                Log.Warning("Wrong Uri");
                return false;
            }
        }
    }
}
