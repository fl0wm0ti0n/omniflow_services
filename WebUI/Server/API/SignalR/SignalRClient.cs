using CommonLib.Toolsets;
using DataTransferObjects.Generic;
using DataTransferObjects.NodeMon;
using InterfacesLib;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebUI.API.SignalR
{
    public class SignalRClient : ISignalRClient, IHostedService
    {
        #region ctor stuff

        private HubConnection _connection;

        public SignalRClient()
        {
            string url;
            try
            {
                Log.Information("Setup SignalR Client ...");
                string address = AppConfig.ReadSetting<string>("SignalR_ServerIp");
                int port = AppConfig.ReadSetting<int>("SignalR_ServerPort");
                bool httpsOn = AppConfig.ReadSetting<bool>("SignalR_HttpsOn");
                string hub = AppConfig.ReadSetting<string>("SignalR_NodeMonHub");
                url = "http://" + address + ":" + port + "/hubs/" + hub;
                if (httpsOn)
                {
                    url = "https://" + address + ":" + port + "/hubs/" + hub;
                }
                Log.Information("... success");
                Log.Information($"Server running on {0}", url);
            }
            catch (Exception e)
            {
                Log.Information(e, "Failed to setup SignalR Client");
                throw;
            }

            _connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        #endregion ctor stuff

        #region Call Hub Functions

        public async Task<List<NodeDto>> GetAllNodes()
        {
            try
            {
                var nodelist = await _connection.InvokeAsync<List<NodeDto>>("S2C_SendAllNodes");

                foreach (var item in nodelist)
                {
                    Log.Information("Fetched Node: " + item.NodeId);
                }
                return nodelist;
                // TODO a function
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetAllNodes");
                return null;
            }
        }

        public async Task<NodeDto> GetSingleNode(int id)
        {
            try
            {
                return await _connection.InvokeAsync<NodeDto>("srv_PushSingleNode", id);
                // TODO a function
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<List<FarmDto>> GetAllFarms()
        {
            try
            {
                return await _connection.InvokeAsync<List<FarmDto>>("srv_PushAllFarms");
                // TODO a function
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public async Task<FarmDto> GetSingleFarm(int id)
        {
            try
            {
                return await _connection.InvokeAsync<FarmDto>("srv_PushSingleFarms", id);
                // TODO a function
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        #endregion Call Hub Functions

        #region Called Client Functions

        public Task SendAsync(string message, string connectionId)
        {
            return Task.CompletedTask;
        }

        public Task SendAsync(string message)
        {
            return Task.CompletedTask;
        }

        public Task SendSingleNode(NodeDto node)
        {
            return Task.CompletedTask;
        }

        public Task SendSingleFarm(FarmDto farm)
        {
            return Task.CompletedTask;
        }

        public Task SendNodeList(List<NodeDto> nodes)
        {
            Log.Information("Success SendNodeList were called");
            try
            {
                foreach (var item in nodes)
                {
                    Log.Error("Fetched Node: " + item.NodeId);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetAllNodes");
                return Task.CompletedTask;
            }
        }

        public Task SendFarmList(List<FarmDto> farm)
        {
            return Task.CompletedTask;
        }

        public Task SendSettingList(List<SettingsDto> settings)
        {
            return Task.CompletedTask;
        }

        #endregion Called Client Functions

        #region StartAsync

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    await _connection.StartAsync(cancellationToken);

                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }
        }

        #endregion StartAsync

        #region StopAsync

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _connection.DisposeAsync();
        }

        #endregion StopAsync
    }
}