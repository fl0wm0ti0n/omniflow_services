using System;
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using NodeMonitor.Controller;
using NodeMonitor.Models;
using NodeMonitor.Protos;

namespace NodeMonitor.Services
{
    public class ThreefoldPublicGrpcService : ThreefoldPublicGrpc.ThreefoldPublicGrpcBase
    {
        private readonly ILogger<ThreefoldPublicGrpcService> _logger;
        private readonly ITFPublicGrpcServiceController _threefoldPublicGrpcController;

        public ThreefoldPublicGrpcService(ILogger<ThreefoldPublicGrpcService> logger, ITFPublicGrpcServiceController threefoldPublicGrpcController)
        {
            _threefoldPublicGrpcController = threefoldPublicGrpcController;
            _logger = logger;
        }



    }
}