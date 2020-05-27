using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NodeMonitor.Models
{
    class JsonInterface
    {
        private readonly nmDBContext _context;
        private readonly IMapper _mapper;

        public JsonInterface(nmDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Creating the source object
        //Employee emp = new Employee
        //{
        //    Name = "James",
        //    Salary = 20000,
        //    Address = "London",
        //    Department = "IT"
        //};
        ////Using automapper
        //var mapper = new Mapper();
        //var empDTO = mapper.Map<EmployeeDTO>(emp);
        ////OR
        ////var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
        ///
        //dbContext.Orders.Persist(mapper).InsertOrUpdate<OrderDTO>(newOrderDto);
        //dbContext.Orders.Persist(mapper).InsertOrUpdate<OrderDTO>(existingOrderDto);
        //dbContext.Orders.Persist(mapper).Remove<OrderDTO>(deletedOrderDto);
        //dbContext.SubmitChanges();

        public void AddFarm(JsonNode JsonFarm)
        {
            using (var context = new nmDBContext())
            {
                context.Farms.Persist(_mapper).InsertOrUpdate(JsonFarm);
                context.SaveChanges();
            }
            
            FarmEntity NewFarm = new FarmEntity()
            {
                //NodeEntity.FarmId = JsonNode.
            };
            
        }

        public void AddNode(JsonNode JsonNode)
        {
            int? farmEntityId = null;
            Log.Warning(JsonNode.FarmId.ToString());

            using (var context = new nmDBContext())
            {

                context.Nodes.Persist(_mapper).InsertOrUpdate(JsonNode);
                context.SaveChanges();
                // Wenn NodeId bereits vorhanden tue nichts
                // TODO: Meldung an Benutzer
                //if (context.Nodes.Any(n => n.NodeId == JsonNode.NodeId)) { UpdateNode(JsonNode); };

                // Prüfe ob FarmId bereits vorhanden ist FarmId in DB
                // TODO: wenn keine Farm mit ID vorhanden muss entweder leere Farm mit ID angelegt werden oder eine Farmabfrage über JsonApi erfolgen.
                // TODO: Meldung an Benutzer

                Log.Warning(JsonNode.FarmId.ToString());
                if (context.Farms.Any(f => f.FarmId == JsonNode.FarmId))
                {
                    var farm = context.Farms
                                        .Single(f => f.FarmId == JsonNode.FarmId);
                    farmEntityId = farm.FarmEntityId;
                }
                else
                {
                    AddFarmFromId(JsonNode.FarmId);
                    var farm = context.Farms
                    .Single(f => f.FarmId == JsonNode.FarmId);
                    farmEntityId = farm.FarmEntityId;
                }

                NodeEntity NewNode = new NodeEntity()
                {
                    Id = JsonNode.Id,
                    NodeId = JsonNode.NodeId,
                    NodeIdV1 = JsonNode.NodeIdV1,
                    FarmId = JsonNode.FarmId,
                    FarmEntityId = farmEntityId,
                    OsVersion = JsonNode.OsVersion,
                    Created = JsonNode.Created,
                    Updated = JsonNode.Updated,
                    Uptime = JsonNode.Uptime,
                    Address = JsonNode.Address,
                    Proofs = JsonNode.Proofs,
                    PublicConfig = JsonNode.PublicConfig,
                    FreeToUse = JsonNode.FreeToUse,
                    Approved = JsonNode.Approved,
                    PublicKeyHex = JsonNode.PublicKeyHex,
                    WgPorts = JsonNode.WgPorts,
                    NodeLocation = new NodeLocationEntity()
                    {
                        CityNode = JsonNode.Location.CityNode,
                        CountryNode = JsonNode.Location.CountryNode,
                        ContinentNode = JsonNode.Location.ContinentNode,
                        LatitudeNode = JsonNode.Location.LatitudeNode,
                        LongitudeNode = JsonNode.Location.LongitudeNode
                    },
                    ReservedResources = new ReservedResourcesEntity()
                    {
                        Cru = JsonNode.ReservedResources.Cru,
                        Mru = JsonNode.ReservedResources.Mru,
                        Hru = JsonNode.ReservedResources.Hru,
                        Sru = JsonNode.ReservedResources.Sru
                    },
                    TotalResources = new TotalResourcesEntity()
                    {
                        Cru = JsonNode.TotalResources.Cru,
                        Mru = JsonNode.TotalResources.Mru,
                        Hru = JsonNode.TotalResources.Hru,
                        Sru = JsonNode.TotalResources.Sru
                    },
                    UsedResources = new UsedResourcesEntity()
                    {
                        Cru = JsonNode.UsedResources.Cru,
                        Mru = JsonNode.UsedResources.Mru,
                        Hru = JsonNode.UsedResources.Hru,
                        Sru = JsonNode.UsedResources.Sru
                    },
                    Workloads = new WorkloadsEntity()
                    {
                        Network = JsonNode.Workloads.Network,
                        Volume = JsonNode.Workloads.Volume,
                        ZdbNamespace = JsonNode.Workloads.ZdbNamespace,
                        Container = JsonNode.Workloads.Container,
                        K8SVm = JsonNode.Workloads.K8SVm,
                        Proxy = JsonNode.Workloads.Proxy,
                        ReverseProxy = JsonNode.Workloads.ReverseProxy,
                        Subdomain = JsonNode.Workloads.ReverseProxy,
                        DelegateDomain = JsonNode.Workloads.DelegateDomain
                    }
                };
                Log.Warning("NewNode: " + NewNode.FarmId.ToString());

                foreach (var iface in JsonNode.Ifaces ?? Enumerable.Empty<Iface>())
                {
                    IfaceEntity NewIface = new IfaceEntity()
                    {
                        Name = iface.Name,
                        Macaddress = iface.Macaddress
                    };
                    Log.Warning("NewIface: " + NewIface.Macaddress);
                    if (!context.Ifaces.Any(n => n.Macaddress == iface.Macaddress))
                    {
                        NewNode.Interfaces.Add(NewIface);
                    };
                    foreach (var addrs in iface.Addrs ?? Enumerable.Empty<string>())
                    {
                        AddrsEntity NewAddrs = new AddrsEntity()
                        {
                            Address = addrs
                        };
                        Log.Warning("NewAddrs: " + NewAddrs.Address);
                        if (!context.Addresses.Any(n => n.Address == addrs))
                        {
                            NewIface.Addrs.Add(NewAddrs);
                        };
                    }
                    foreach (var gateway in iface.Gateway ?? Enumerable.Empty<string>())
                    {
                        GatewayEntity NewGateway = new GatewayEntity()
                        {
                            Address = gateway
                        };
                        Log.Warning("NewGateway: " + NewGateway.Address);
                        if (!context.Gateways.Any(n => n.Address == gateway))
                        {
                            NewIface.Gateway.Add(NewGateway);
                        };
                    }
                }

                context.Nodes.Add(NewNode);

                //context.Update<NodeEntity>(NewNode);
                context.SaveChanges();
            }
        }

        public void UpdateNode(JsonNode JsonNode)
        {
        }

        public void UpdateFarm(JsonNode JsonNode)
        {
        }

        public void AddFarmFromId(long Id)
        {
            using (var context = new nmDBContext())
            {
                FarmEntity NewFarm = new FarmEntity()
                {
                    FarmId = Id
                };
                context.Farms.Add(NewFarm);
                context.SaveChanges();
            }
        }
    }
}
