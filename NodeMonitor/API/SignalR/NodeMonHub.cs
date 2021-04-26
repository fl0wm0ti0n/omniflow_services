using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using NodeMonitor.Business;
using NodeMonitor.Models;
using Serilog;
using InterfacesLib;
using DataTransferObjects.Generic;
using NodeMonitor.Controller;
using AutoMapper;
using System.Collections.Generic;
using DataTransferObjects.NodeMon;
using System.Linq;

namespace NodeMonitor.API.SignalR
{
    /*
    MyHub, the SignalR Hub class that the application will provide to clients.This class has a single 
    method, Send, that clients will call to broadcast a message to all other connected clients.
    */
    public class NodeMonHub : Hub<ISignalRClient>
    {
        private IMapper _mapper;
        private nmDBContext _dbContext;
        private IDtoTransferController _dtoTransferController;

        public NodeMonHub(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public override Task OnConnectedAsync()
        {
            //DtoTransferController _dtoTransferController = new DtoTransferController();

            Log.Information("Connection established: " + Context.ConnectionId);
        
            //Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID: " + Context.ConnectionId);
            //Clients.Others.SendAsync("Client with ID {0} connected to the NodeMon", Context.ConnectionId);
        
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception e)
        {
            Log.Information("Connection closed: " + Context.ConnectionId);

            // TODO
            return base.OnDisconnectedAsync(e);
        }

        [HubMethodName("S2C_SendAllNodes")]
        public async Task SendAllNodes()
        {
            using (var _dbContext = new nmDBContext())
            {
                try
                {
                    Log.Information("Send all Nodes to Client with Conn ID " + Context.ConnectionId);
                    var nodes = _mapper.Map<List<NodeDto>>(_dbContext.Nodes.ToList());
                    Log.Information(nodes.ToString());
                    await Clients.Caller.SendNodeList(nodes);
                    Log.Information("Success list of Nodes were sent to client");
                }
                catch (Exception e)
                {
                    Log.Information(e, "An Error occured by trying to send 'SendAllNodes'");
                }
            }
        }

        [HubMethodName("S2C_SendMessage2All")]
        public async Task SendMessage2All(string message)
        {
            try
            {
                Log.Information(Context.ConnectionId + ":" + message);
                await Clients.All.SendAsync(message);
            }
            catch (Exception e)
            {
                Log.Information("An Error occured by trying to send 'SendMessage2All' {0}", e);
            }
        }

        [HubMethodName("S2C_SendSingleNode")]
        public async Task SendSingleNode(int id)
        {
            try
            {
                Log.Information("Client with ConnId " + Context.ConnectionId + " asks for Node with Id" + id);
                var nodes = _mapper.Map<NodeDto>(_dbContext.Nodes.Find(id));
                await Clients.Caller.SendSingleNode(nodes);
                Log.Information("Success Node with Id " + id + " was sent to client");
            }
            catch (Exception e)
            {
                Log.Information("An Error occured by trying to send 'SendSingleNode' {0}", e);
            }
        }

        [HubMethodName("S2C_SendAllFarms")]
        public async Task SendAllFarms()
        {
            try
            {
                Log.Information("Client with ConnId " + Context.ConnectionId + " asks for all Farms");
                var farms = _mapper.Map<List<FarmDto>>(_dbContext.Farms.ToList());
                await Clients.Caller.SendFarmList(farms);
                Log.Information("Success list of Farms were sent to client");
            }
            catch (Exception e)
            {
                Log.Information("An Error occured by trying to send 'SendAllFarms' {0}", e);
            }
        }

        [HubMethodName("S2C_SendSingleFarm")]
        public async Task SendSingleFarm(int id)
        {
            try
            {
                Log.Information("Client with ConnId " + Context.ConnectionId + " asks for Farm with Id" + id);
                var farm = _mapper.Map<FarmDto>(_dbContext.Farms.Find(id));
                await Clients.Caller.SendSingleFarm(farm);
                Log.Information("Success Farm with Id " + id + " was sent to client");
            }
            catch (Exception e)
            {
                Log.Information("An Error occured by trying to send 'SendSingleFarm' {0}", e);
            }
        }

        [HubMethodName("S2C_SendAllSettings")]
        public async Task SendAllSettings()
        {
            try
            {
                Log.Information("Client with ConnId " + Context.ConnectionId + " asks for all Settings");
                var settings = _mapper.Map<List<SettingsDto>>(_dbContext.Settings.ToList());
                await Clients.All.SendSettingList(settings);
                Log.Information("Success list of Settings were sent to client");
            }
            catch (Exception e)
            {
                Log.Information("An Error occured by trying to send 'SendAllSettings' {0}", e);
            }
        }
    }
}
