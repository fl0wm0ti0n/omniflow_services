using System;
using Microsoft.AspNetCore.SignalR;
using NodeMonitor.Business;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NodeMonitor.API.SignalR;
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
            // Start SignalR
            try
            {
                Log.Information("Starting up SignalR Server");
                services.AddSignalR();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting SignalR Server");
                return;
            }

            // Start all Services
            try
            {
                Log.Information("Starting up AutoMapper");

                services.AddAutoMapper(c => c.AddProfile<nmMapperConfig>(), typeof(Startup));
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem starting AutoMapper");
                return;
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
                Log.Information("Add Hub Route '/hubs/nodemon'");
                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapHub<NodeMonHub>("/hubs/nodemon");
                });
            }
            catch (Exception e)
            {
                Log.Fatal(e, "There was a problem Add Hub Route '/hubs/nodemon'");
                return;
            }
        }
    }
}