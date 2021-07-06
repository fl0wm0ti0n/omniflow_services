using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Toolsets;
using Grpc.Net.Client;
using Serilog;
using WebUI.Server.Protos;

namespace WebUI.Server.API.Client
{
    public class GrpcClientBase : IGrpcClientBase
    {
        protected GrpcChannel Channel;
        public GrpcClientBase()
        {
            string grpcUri;
            try
            {
                var grpcPort = AppConfig.ReadSetting<string>("GrpcClient_TargetPort");
                var rawUri = new Uri(AppConfig.ReadSetting<string>("GrpcClient_TargetIp"));

                if (AppConfig.ReadSetting<bool>("GrpcClient_HttpsOn"))
                {
                    grpcUri = $"https://{rawUri}:{grpcPort}/";
                }
                else
                {
                    grpcUri = $"http://{rawUri}:{grpcPort}/";
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Exception creating GrpcUri");
                throw;
            }
            Channel = GrpcChannel.ForAddress(grpcUri);
        }
    }
}
