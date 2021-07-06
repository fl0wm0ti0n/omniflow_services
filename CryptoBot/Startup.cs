using System;
using CryptoBot.Contracts;
using CryptoBot.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CryptoBot.Services;
using Microsoft.OpenApi.Models;

namespace CryptoBot
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            bool _IsGrpc = false;
            services.AddGrpcHttpApi();
            services.AddGrpc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CryptoBot", Version = "v1" });
            });
            services.AddGrpcSwagger();

            services.AddScoped<ICustomerController, CustomerController>();
            if (_IsGrpc)
            {
                services.AddScoped<ICustomerGrpcClient, CustomerGrpcClient>(s => new CustomerGrpcClient(new Uri("http://CryptoBot:55001")));
                services.AddScoped<ICustomerApiClient, CustomerApiClient>(s => new CustomerApiClient(new Uri("http://CryptoBot:55001")));
            }
            else
            {
                services.AddScoped<ICustomerGrpcClient, CustomerGrpcClient>(s => new CustomerGrpcClient(new Uri("http://CryptoBot:55001")));
                services.AddScoped<ICustomerApiClient, CustomerApiClient>(s => new CustomerApiClient(new Uri("http://CryptoBot:55001")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoBot V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CustomerService>();
            });
        }
    }
}