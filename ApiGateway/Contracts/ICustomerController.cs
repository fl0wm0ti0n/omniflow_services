using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using ApiGateway.Protos;

namespace ApiGateway.Contracts
{
    public interface ICustomerController
    {
        CustomerGrpcModel GetCustomerInfo(CustomerLookupRequest request);
        Task<bool> GetNewCustomers(IServerStreamWriter<CustomerGrpcModel> responseStream);
        ListCustomerReply ListNewCustomers(ListCustomerRequest request);
        CustomerGrpcModel CreateCustomer(CreateCustomerRequest request);
        ListCustomerNamesReply GetCustomerNames(CustomerLookupNameRequest request);
    }
}
