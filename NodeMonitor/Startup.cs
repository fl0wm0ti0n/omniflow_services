using System;
using Microsoft.AspNetCore.SignalR;
using NodeMonitor.Business;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NodeMonitor.API.Client;
using NodeMonitor.Controller;
using NodeMonitor.Services;
using Serilog;

namespace NodeMonitor
{

    public class Startup
    {
        /*
        Startup, the class containing the configuration for the SignalR server(the only configuration this tutorial uses 
        is the call to UseCors), and the call to MapSignalR, which creates routes for any Hub objects in the project.
        */

        public void ConfigureServices(IServiceCollection services)
        {
            // add Grpc and Swagger
            try
            {
                Log.Information("Starting Grpc and GrpcsSwagger...");
                services.AddSignalR();

                services.AddGrpcHttpApi();
                services.AddGrpc();

                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NodeMon Grpc-WebApi", Version = "v1" });
                });
                services.AddGrpcSwagger();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting Grpc Service or GrpcSwagger");
                throw;
            }

            // Start all Services
            try
            {
                Log.Information("Starting up AutoMapper...");

                services.AddAutoMapper(c => c.AddProfile<MapperConfig>(), typeof(Startup));
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting AutoMapper");
                throw;
            }

            // Add DI Scoped
            try
            {
                Log.Information("Add Scoped DI...");
                services.AddScoped<ITFPublicGrpcServiceController, TFPublicGrpcServiceController>();
                services.AddScoped<IThreefoldPublicApiClient, ThreefoldPublicApiClient>();
                services.AddScoped<ITFPublicWebApiClientController, TFPublicWebApiClientController>();
                services.AddScoped<ITFPublicEntityController, TFPublicEntityController>();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem adding Scoped DI");
                throw;
            }
        }

        // configure and Build Hub
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add Endpoints all Services
            try
            {
                Log.Information("Add Endpoints...");
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGrpcService<ThreefoldPublicGrpcService>();
                });

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NodeMon Grpc-WebApi V1");
                });
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem Add one or more of Endpoints.");
                throw;
            }

        }
    }
}