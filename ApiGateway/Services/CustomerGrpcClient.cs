using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using ApiGateway.Contracts;
using Models.ThreeFoldModels;
using ApiGateway.Protos;

namespace ApiGateway.Services
{
    public class CustomerGrpcClient : GrpcClientBase, ICustomerGrpcClient
    {
        protected Customer.CustomerClient CustomerClient;

        public CustomerGrpcClient(Uri uri) : base(uri)
        {
            CustomerClient = new Customer.CustomerClient(Channel);
        }

        public async Task<CustomerGrpcModel> GetCustomerInfo(CustomerLookupRequest request)
        {
            var customer = await CustomerClient.GetCustomerInfoAsync(request);
            return customer;
        }

        public async Task<bool> GetNewCustomers(IServerStreamWriter<CustomerGrpcModel> responseStream)
        {
            using (var call = CustomerClient.GetNewCustomers(new NewCustomerRequest()))
            {
                while (await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;
                    await responseStream.WriteAsync(currentCustomer);
                }
            }

            return true;
        }

        public async Task<ListCustomerReply> ListNewCustomers()
        {
            var customerList = await CustomerClient.ListNewCustomersAsync(new ListCustomerRequest());
            return customerList;
        }

        public async Task<CustomerGrpcModel> CreateCustomer(CreateCustomerRequest request)
        {
            var newcustomerReply = await CustomerClient.CreateCustomerAsync(request);
            return newcustomerReply;
        }

        public async Task<ListCustomerNamesReply> GetCustomerNames(CustomerLookupNameRequest request)
        {
            var customerList = await CustomerClient.GetCustomerNamesAsync(request);
            return customerList;
        }
	}
}