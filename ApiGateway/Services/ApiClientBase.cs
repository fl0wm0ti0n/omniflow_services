using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.Contracts;

namespace ApiGateway.Services
{
    public class ApiClientBase : IApiClientBase
    {
        protected HttpClient Client;

        public ApiClientBase(Uri uri)
        {
            try
            {
                Client = new HttpClient();
                Client.BaseAddress = uri;
                Client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
                Client.DefaultRequestVersion = HttpVersion.Version20;
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
