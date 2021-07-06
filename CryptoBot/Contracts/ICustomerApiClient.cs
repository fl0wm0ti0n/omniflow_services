using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Models.CryptoTradeModels;
using CryptoBot.Protos;

namespace CryptoBot.Contracts
{
    public interface ICustomerApiClient : IApiClientBase
    {
        Task<Uri> CreateCustomerAsync(CustomerModel customer);
        Task<CustomerModel> GetCustomerAsync();
        Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer);
        Task<HttpStatusCode> DeleteCustomerAsync(string id);
        Task<CustomerModel> GetCustomerInfo(CustomerLookupRequest customerRequest);
        Task<CustomerModel> CreateCustomer(CreateCustomerRequest customer);
        Task<CustomerModel> ListNewCustomers();
        Task<CustomerModel> GetCustomerNames(CustomerLookupNameRequest age);
    }
}
