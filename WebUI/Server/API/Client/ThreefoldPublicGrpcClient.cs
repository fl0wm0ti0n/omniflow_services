using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Models.ThreeFoldModels;
using WebUI.Server.Protos;

namespace WebUI.Server.API.Client
{
    public class ThreefoldPublicGrpcClient : GrpcClientBase, IThreefoldPublicGrpcClient
    {
        protected ThreefoldPublicGrpc.ThreefoldPublicGrpcClient GrpcClient;

        public ThreefoldPublicGrpcClient()
        {
            GrpcClient = new ThreefoldPublicGrpc.ThreefoldPublicGrpcClient(Channel);
        }
    }
}