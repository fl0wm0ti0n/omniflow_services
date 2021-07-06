using System;
using System.Collections.Generic;
using System.Linq;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Grpc.Net.Client;
using CryptoBot.Contracts;
using CryptoBot.Controller;
using Models.CryptoTradeModels;
using CryptoBot.Protos;

namespace CryptoBot.Services
{

    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerController _customerController;

        public CustomerService(ILogger<CustomerService> logger, ICustomerController customerController)
        {
            _customerController = customerController;
            _logger = logger;
        }
        public override Task<CustomerGrpcModel> GetCustomerInfo(CustomerLookupRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called GetCustomerInfo");
            return Task.FromResult(_customerController.GetCustomerInfo(request));
        }
        public override async Task GetNewCustomers(NewCustomerRequest request, IServerStreamWriter<CustomerGrpcModel> responseStream, ServerCallContext context)
        {
            Console.WriteLine("Called GetNewCustomers");
           var value = await _customerController.GetNewCustomers(responseStream);
        }

        public override Task<ListCustomerReply> ListNewCustomers(ListCustomerRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called ListNewCustomers");
            return Task.FromResult(_customerController.ListNewCustomers(request));
        }

        public override Task<CustomerGrpcModel> CreateCustomer(CreateCustomerRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called CreateCustomer");
            return Task.FromResult(_customerController.CreateCustomer(request));
        }

        public override Task<ListCustomerNamesReply> GetCustomerNames(CustomerLookupNameRequest request, ServerCallContext context)
        {
            Console.WriteLine("Called GetCustomerNames");
            return Task.FromResult(_customerController.GetCustomerNames(request));
        }
    }
}