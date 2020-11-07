using DatabaseLib.Entities;
using Microsoft.Extensions.Hosting;
using NodeMonitor.Business;
using NodeMonitor.Models;
using NodeMonitor.Test;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NodeMonitor
{
    public class Worker : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Start the Service: {time}", DateTimeOffset.Now);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("The Service has been stopped: {time}", DateTimeOffset.Now);

            Testdata.DeleteTestdata();

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //var context = new nmDBContext();
            //ThreefoldApiUriEntity NodesUri = null;
            //NodesUri = context.ThreefoldApiUris.Single(n => n.Name == "AllNodes");

            while (!stoppingToken.IsCancellationRequested)
            {
                // Task welcher ausgeführt wird bis er gestopppt wird;

                /*
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("The website is up. Status code {StatusCode}", result.StatusCode);
                }
                else
                {
                    _logger.LogError("The website is down. Status code {StatusCode}", result.StatusCode);
                }
                */

                //JsonToEntity.AddNodeHistoryList(DeserealizeJson.CheckUriForNodeListAndGetJson(NodesUri));

                Log.Information("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(600*5000, stoppingToken);
            }
        }
    }
}