using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CryptoBot.Contracts;
using Models.CryptoTradeModels;
using CryptoBot.Protos;

namespace CryptoBot.Services
{
    public class CustomerApiClient : ApiClientBase, ICustomerApiClient
    {

        public CustomerApiClient(Uri uri) : base(uri)
        {
            
        }
        public async Task<Uri> CreateCustomerAsync(CustomerModel customer)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                "/api/v1/customer", customer);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<CustomerModel> GetCustomerAsync()
        {
            CustomerModel customer = null;
            HttpResponseMessage response = await Client.GetAsync("/api/v1/customer");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            }

            return customer;
        }

        public async Task<CustomerModel> UpdateCustomerAsync(CustomerModel customer)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync(
                $"/api/v1/customer/{ customer.Id }", customer);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            return customer;
        }

        public async Task<HttpStatusCode> DeleteCustomerAsync(string id)
        {
            HttpResponseMessage response = await Client.DeleteAsync(
                $"/api/v1/customer/{ id }");
            return response.StatusCode;
        }

        public async Task<CustomerModel> GetCustomerInfo(CustomerLookupRequest customerRequest)
        {
            CustomerModel customer = null;
            HttpResponseMessage response = await Client.GetAsync($"/api/v1/customer/{customerRequest.UserId}");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            }

            return customer;
        }

        public async Task<CustomerModel> ListNewCustomers()
        {
            CustomerModel customer = null;
            HttpResponseMessage response = await Client.GetAsync("/api/v1/customer/listcustomers");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            }
            return customer;
        }

        public async Task<CustomerModel> CreateCustomer(CreateCustomerRequest customer)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(
                "/api/v1/customer", customer);
            response.EnsureSuccessStatusCode();
            var customer2 = response.Content.ReadFromJsonAsync<CustomerModel>().Result;
            //CustomerModel customer2 = null;
            //HttpResponseMessage response2 = await Client.GetAsync(response.Headers.Location);
            //if (response.IsSuccessStatusCode)
            //{
            //    customer2 = await response.Content.ReadFromJsonAsync<CustomerModel>();
            //}

            return customer2;
        }

        public async Task<CustomerModel> GetCustomerNames(CustomerLookupNameRequest age)
        {
            CustomerModel customer = null;
            HttpResponseMessage response = await Client.GetAsync($"/api/v1/GetFirstNames/{ age }");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<CustomerModel>();
            }
            return customer;
        }
    }
}
