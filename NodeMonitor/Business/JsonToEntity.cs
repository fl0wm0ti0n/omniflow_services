using Microsoft.EntityFrameworkCore.Internal;
using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;
using System.Linq;
using Serilog;
using Serilog.Events;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.Collection;
using AutoMapper.EquivalencyExpression;
using AutoMapper.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace NodeMonitor.Business
{
    public static class JsonToEntity
    {
        // 
        // Speichert Farm in Datenbank wenn FarmID noch nicht vorhanden
        //
        public static bool AddFarm(JsonFarm JsonFarm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JsonFarm, FarmEntity>();
                cfg.CreateMap<FarmLocation, FarmLocationEntity>();
                cfg.CreateMap<WalletAddress, WalletAddressEntity>();
                cfg.CreateMap<ResourcePrice, ResourcePriceEntity>();
            });

            using (var context = new nmDBContext())
            {
                Log.Information("Try to save Farm with ID " + JsonFarm.FarmId.ToString());
                if (!context.Farms.Any(n => n.FarmId == JsonFarm.FarmId))
                {
                    try
                    {
                        var mapper = new Mapper(config);
                        var NewFarm = mapper.Map<FarmEntity>(JsonFarm);
                        context.Farms.Add(NewFarm);
                        context.SaveChanges();
                        Log.Information("Successfully saved Farm with ID " + JsonFarm.FarmId.ToString());
                        return true;
                    }
                    catch (Exception e)
                    {
                        Log.Warning("Something went wrong by saving Farm with ID " + JsonFarm.FarmId.ToString(), e);
                        return false;
                    }
                    finally
                    {
                        //TODO ?
                    };
                }
                else
                {
                    Log.Warning("Farm with ID " + JsonFarm.FarmId.ToString() + " is already saved in DB" );
                    return false;
                };
            }
        }

        // 
        // Speichert Node in Datenbank wenn NodeID noch nicht vorhanden
        //
        public static bool AddNode(JsonNode JsonNode)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JsonNode, NodeEntity>();
                cfg.CreateMap<NodeLocation, NodeLocationEntity>();
                cfg.CreateMap<TotalResources, TotalResourcesEntity>();
                cfg.CreateMap<ReservedResources, ReservedResourcesEntity>();
                cfg.CreateMap<UsedResources, UsedResourcesEntity>();
                cfg.CreateMap<Workloads, WorkloadsEntity>();
            });

            using (var context = new nmDBContext())
            {
                int? farmEntityPK = null;
                Log.Information("Try to save Node with ID " + JsonNode.Id.ToString());
                if (!context.Nodes.Any(n => n.NodeId == JsonNode.NodeId))
                {
                    try
                    {
                        // Prüfe ob FarmId aus Node.FarmID in DB ist wenn ja nimm vorhandenen Farm.PrimaryKey ansonsten erstelle neu Farm nur anhand der Node.FarmId
                        if (context.Farms.Any(f => f.FarmId == JsonNode.FarmId))
                        {
                            var farm = context.Farms
                                                .Single(f => f.FarmId == JsonNode.FarmId);
                            farmEntityPK = farm.FarmEntityId;
                        }
                        else
                        {
                            AddFarmFromId(JsonNode.FarmId);
                            var farm = context.Farms
                            .Single(f => f.FarmId == JsonNode.FarmId);
                            farmEntityPK = farm.FarmEntityId;
                        }

                        // Map all values from Jason to EFEntity
                        var mapper = new Mapper(config);
                        NodeEntity NewNode = mapper.Map<NodeEntity>(JsonNode);
                        // TODO: Mapper cant convert and create farm to Node so it have to be linked manually
                        NewNode.FarmEntityId = farmEntityPK;

                        context.Nodes.Add(NewNode);

                        //TODO: Mapper cant convert and create Ifaces with Addrs and gateways Lists so it have to be created manually
                        foreach (var ifaceItem in JsonNode.Ifaces ?? Enumerable.Empty<Iface>())
                        {
                            string ad = "";
                            string gw = "";
                            if (ifaceItem.Addrs != null)    { ad = string.Join(",", ifaceItem.Addrs.Where(s => !string.IsNullOrEmpty(s))); }
                            if (ifaceItem.Gateway != null)  { gw = string.Join(",", ifaceItem.Gateway.Where(s => !string.IsNullOrEmpty(s))); }
                        
                            if (!context.Interfaces.Any(n => n.Macaddress == ifaceItem.Macaddress))
                            {
                                IfaceEntity NewIface = new IfaceEntity()
                                {
                                    Name            = ifaceItem.Name,
                                    Macaddress      = ifaceItem.Macaddress,
                                    Addrs           = ad,
                                    Gateway         = gw,
                                    NodeEntity      = NewNode
                                };
                                context.Interfaces.Add(NewIface);
                            };
                        }
                        context.SaveChanges();
                        Log.Information("Successfully saved Node with ID " + JsonNode.Id.ToString());
                        return true;
                    }
                    catch (Exception e)
                    {
                        Log.Warning("Something went wrong by saving Node with ID " + JsonNode.Id.ToString(), e);
                        return false;
                    }
                    finally
                    {
                        //TODO: ?
                    };
                }
                else
                {
                    Log.Warning("Node with ID " + JsonNode.Id.ToString() + " is already saved in DB");
                    return false;
                };
            }
        }

        //
        // Aktualisiert Node in Datenbank
        //
        public static bool UpdateNode(JsonNode JsonNode)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JsonNode, NodeEntity>();
                cfg.CreateMap<NodeLocation, NodeLocationEntity>();
                cfg.CreateMap<TotalResources, TotalResourcesEntity>();
                cfg.CreateMap<ReservedResources, ReservedResourcesEntity>();
                cfg.CreateMap<UsedResources, UsedResourcesEntity>();
                cfg.CreateMap<Workloads, WorkloadsEntity>();
            });

            using (var context = new nmDBContext())
            {
                Log.Information("Try to update Node with ID " + JsonNode.Id.ToString());
                if (context.Nodes.Any(n => n.NodeId == JsonNode.NodeId))
                {
                    try
                    {
                        var mapper = new Mapper(config);
                        var NewNode = mapper.Map<NodeEntity>(JsonNode);
                        context.Nodes.Update(NewNode);
                        context.SaveChanges();
                        Log.Information("Successfully updated Node with ID " + JsonNode.Id.ToString());
                        return true;
                    }
                    catch (Exception e)
                    {
                        Log.Warning("Something went wrong by updating Node with ID " + JsonNode.Id.ToString(), e);
                        return false;
                    }
                    finally
                    {
                        //TODO ?
                    };
                }
                else
                {
                    Log.Warning("Node with ID " + JsonNode.Id.ToString() + " is not in DB - nothing to update");
                    return false;
                };
            }
        }

        //
        // Aktualisiert Farm in Datenbank wenn FarmID vorhanden.
        //
        public static bool UpdateFarm(JsonFarm JsonFarm)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JsonFarm, FarmEntity>();
                cfg.CreateMap<FarmLocation, FarmLocationEntity>();
                cfg.CreateMap<WalletAddress, WalletAddressEntity>();
                cfg.CreateMap<ResourcePrice, ResourcePriceEntity>();
            });

            using (var context = new nmDBContext())
            {
                Log.Information("Try to update Farm with ID " + JsonFarm.FarmId.ToString());
                if (!context.Farms.Any(n => n.FarmId == JsonFarm.FarmId))
                {
                    try
                    {
                        var mapper = new Mapper(config);
                        var NewFarm = mapper.Map<FarmEntity>(JsonFarm);

                        context.Farms.Add(NewFarm);
                        context.SaveChanges();
                        Log.Information("Successfully updated Node with ID " + JsonFarm.FarmId.ToString());
                        return true;
                    }
                    catch (Exception e)
                    {
                        Log.Warning("Something went wrong by updating Farm with ID " + JsonFarm.FarmId.ToString(), e);
                        return false;
                    }
                    finally
                    {
                        //TODO ?
                    };
                }
                else
                {
                    Log.Warning("Farm with ID " + JsonFarm.FarmId.ToString() + " is not in DB - nothing to update");
                    return false;
                };
            }
        }

        public static bool AddNodeHistoryItem(JsonNode JsonNode)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<JsonNode, NodeHistoryEntity>();
                cfg.CreateMap<NodeLocation, NodeLocationHistoryEntity>();
                cfg.CreateMap<TotalResources, TotalResourcesHistoryEntity>();
                cfg.CreateMap<ReservedResources, ReservedResourcesHistoryEntity>();
                cfg.CreateMap<UsedResources, UsedResourcesHistoryEntity>();
            });

            using (var context = new nmDBContext())
            {
                // Prüfe ob NodeId aus Node.NodeID in DB ist wenn ja nimm vorhandenen Node.PrimaryKey ansonsten erstelle neue Node
                int? nodeEntityPK = null;
                if (context.Nodes.Any(n => n.NodeId == JsonNode.NodeId))
                {
                    var node = context.Nodes.Single(n => n.NodeId == JsonNode.NodeId);
                    nodeEntityPK = node.NodeEntityId;
                }
                else
                {
                    AddNode(JsonNode);
                    var node = context.Nodes.Single(n => n.NodeId == JsonNode.NodeId);
                    nodeEntityPK = node.NodeEntityId;
                }

                Log.Information("Try to save NodeHistory with Node ID " + JsonNode.Id.ToString());
                try
                {

                    // Map all values from Jason to EFEntity
                    var mapper = new Mapper(config);
                    NodeHistoryEntity NewNode = mapper.Map<NodeHistoryEntity>(JsonNode);
                    NewNode.NodeEntityId = nodeEntityPK;


                    context.NodeHistories.Add(NewNode);
                    context.SaveChanges();
                    Log.Information("Successfully saved NodeHistory with Node ID " + JsonNode.Id.ToString());
                    return true;
                }
                catch (Exception e)
                {
                    Log.Warning("Something went wrong by NodeHistory with Node ID " + JsonNode.Id.ToString(), e);
                    return false;
                }
                finally
                {
                    //TODO: ?
                };
            }
        }

        //
        // Speichert Farm nur mit FarmID in Datenbank.
        //
        public static void AddFarmFromId(long Id)
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