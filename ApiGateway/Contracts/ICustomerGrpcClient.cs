using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Grpc.Core;
using Models.CryptoTradeModels;
using ApiGateway.Protos;

namespace ApiGateway.Contracts
{
    public interface ICustomerGrpcClient
    {
        Task<CustomerGrpcModel> GetCustomerInfo(CustomerLookupRequest customerRequest);
        Task<bool> GetNewCustomers(IServerStreamWriter<CustomerGrpcModel> responseStream);
        Task<ListCustomerReply> ListNewCustomers();
        Task<CustomerGrpcModel> CreateCustomer(CreateCustomerRequest request);
        Task<ListCustomerNamesReply> GetCustomerNames(CustomerLookupNameRequest request);
    }
}
