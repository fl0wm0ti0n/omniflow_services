using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Models.CryptoTradeModels;
using NodeMonitor.API.Client;
using NodeMonitor.Protos;
using NodeMonitor.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NodeMonitor.Controller
{

    public class TFPublicGrpcServiceController : ITFPublicGrpcServiceController
    {
        public TFPublicGrpcServiceController()
        {
        }
    }
}