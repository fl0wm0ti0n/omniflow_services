﻿using AutoMapper;
using NodeMonitor.Models;
using DatabaseLib.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using NodeMonitor.Models.JsonModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeMonitor.Business
{
    public class JsonToEntity
    {

        public JsonToEntity()
        {

        }

        //#######################################################################
        //# Speichert Farm Liste in Datenbank wenn FarmID noch nicht vorhanden  #
        //#######################################################################
        public static bool AddFarmList(List<JsonFarm> JsonFarmList)
        {
            foreach (var item in JsonFarmList)
            {
                var value = AddFarm(item);
                if (value = false)
                {
                    //TODO
                }
            };
            return true;
        }

        //#######################################################################
        //# Speichert Node Liste in Datenbank wenn NodeID noch nicht vorhanden  #
        //#######################################################################
        public static bool AddNodeList(List<JsonNode> JsonNodeList)
        {
            foreach (var item in JsonNodeList)
            {
                var value = AddNode(item);
                if (value = false)
                {
                    //TODO
                }
            };
            return true;
        }

        //#############################################
        //# Speichert NodeHistory Liste in Datenbank  #
        //#############################################
        public static bool AddNodeHistoryList(List<JsonNode> JsonNodeList)
        {
            foreach (var item in JsonNodeList)
            {
                var value = AddNodeHistoryItem(item);
                if (value = false)
                {
                    //TODO
                }
            };
            return true;
        }

        //#################################################################
        //# Speichert Farm in Datenbank wenn FarmID noch nicht vorhanden  #
        //#################################################################
        public static bool AddFarm(JsonFarm JsonFarm)
        {
            var config = new MapperConfiguration(cfg =>
            {
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
                    Log.Warning("Farm with ID " + JsonFarm.FarmId.ToString() + " is already saved in DB");
                    return false;
                };
            }
        }

        //#################################################################
        //# Speichert Node in Datenbank wenn NodeID noch nicht vorhanden  #
        //#################################################################
        public static bool AddNode(JsonNode JsonNode)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JsonNode, NodeEntity>()
                    .ForMember(d => d.Updated, opt => opt.ConvertUsing(new ConvertUnixTimeStampToDateTime()))
                    .ForMember(d => d.Created, opt => opt.ConvertUsing(new ConvertUnixTimeStampToDateTime()))
                    .ForMember(d => d.Uptime, opt => opt.ConvertUsing(new ConvertSecondsToDateTime()));
                cfg.CreateMap<NodeLocation, NodeLocationEntity>();
                cfg.CreateMap<TotalResources, TotalResourcesEntity>();
                cfg.CreateMap<ReservedResources, ReservedResourcesEntity>();
                cfg.CreateMap<UsedResources, UsedResourcesEntity>();
                cfg.CreateMap<Workloads, WorkloadsEntity>();
                cfg.CreateMap<PublicConfig, PublicConfigEntity>();
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

                        string wgp = "";
                        if (JsonNode.WgPorts != null) { wgp = string.Join(",", JsonNode.WgPorts.Where(s => !string.IsNullOrEmpty(s.ToString()))); }

                        // Convert to DateTime
                        //NewNode.Created     = UnixTimeStampToDateTime(JsonNode.Created);
                        //NewNode.Updated     = UnixTimeStampToDateTime(JsonNode.Updated);
                        //NewNode.Uptime      = SecondsToDateTime(JsonNode.Uptime);
                        Log.Information("Converted Created-Time from " + JsonNode.Created + " to " + NewNode.Created);
                        Log.Information("Converted Updated-Time from " + JsonNode.Updated + " to " + NewNode.Updated);
                        Log.Information("Converted Uptime-Time from " + JsonNode.Uptime + " to " + NewNode.Uptime);

                        context.Nodes.Add(NewNode);

                        //TODO: Mapper cant convert and create Ifaces with Addrs and gateways Lists so it have to be created manually
                        foreach (var ifaceItem in JsonNode.Ifaces ?? Enumerable.Empty<Iface>())
                        {
                            string ad = "";
                            string gw = "";
                            if (ifaceItem.Addrs != null) { ad = string.Join(",", ifaceItem.Addrs.Where(s => !string.IsNullOrEmpty(s))); }
                            if (ifaceItem.Gateway != null) { gw = string.Join(",", ifaceItem.Gateway.Where(s => !string.IsNullOrEmpty(s))); }

                            if (!context.Interfaces.Any(n => n.Macaddress == ifaceItem.Macaddress))
                            {
                                IfaceEntity NewIface = new IfaceEntity()
                                {
                                    Name = ifaceItem.Name,
                                    Macaddress = ifaceItem.Macaddress,
                                    Addrs = ad,
                                    Gateway = gw,
                                    NodeEntity = NewNode
                                };
                                context.Interfaces.Add(NewIface);
                            };
                        }
                        context.SaveChanges();
                        Log.Information("Successfully saved Node with ID " + JsonNode.Id.ToString());
                        return true;
                    }
                    catch (AutoMapperMappingException e)
                    {
                        Log.Warning("Something went wrong by saving Node with ID " + JsonNode.Id.ToString() + "; {0}", e);
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

        //######################################
        //# Speichert NodeHistory in Datenbank #
        //######################################
        public static bool AddNodeHistoryItem(JsonNode JsonNode)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JsonNode, NodeHistoryEntity>()
                    .ForMember(d => d.Updated, opt => opt.ConvertUsing(new ConvertUnixTimeStampToDateTime()))
                    .ForMember(d => d.Uptime, opt => opt.ConvertUsing(new ConvertSecondsToDateTime()));
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

                    // Convert to DateTime
                    //NewNode.Updated = UnixTimeStampToDateTime(JsonNode.Updated);
                    //NewNode.Uptime = SecondsToDateTime(JsonNode.Uptime);

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

        //###########################################
        //# Speichert LeereFarm mit Id in Datenbank #
        //###########################################
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

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static DateTime SecondsToDateTime(long secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);
        
            string answer = string.Format("{0:D2}h:{1:D2}h:{2:D2}m:{3:D2}s:{4:D3}ms",
                t.Days,
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
        
            return Convert.ToDateTime(answer);
        }
    }

    public class ConvertUnixTimeStampToDateTime : IValueConverter<long, DateTime>
    {
        public DateTime Convert(long unixTimeStamp, ResolutionContext context)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }

    public class ConvertSecondsToDateTime : IValueConverter<long, TimeSpan>
    {
        public TimeSpan Convert(long secs, ResolutionContext context)
        {
            TimeSpan time = TimeSpan.FromSeconds(secs);
            //DateTime dateTime = DateTime.Today.Add(time);
            //string displayTime = dateTime.ToString("dd:hh:mm:tt");
            return time;
        }
    }
}