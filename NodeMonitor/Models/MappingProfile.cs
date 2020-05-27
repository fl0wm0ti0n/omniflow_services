using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using DatabaseLib.Entities;
using NodeMonitor.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeMonitor.Models
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<JsonFarm, FarmEntity>();
            CreateMap<FarmLocation, FarmLocationEntity> ();
            CreateMap<WalletAddress, WalletAddressEntity>();

            var FarmMap = CreateMap<JsonFarm, FarmEntity>();
            FarmMap.ForMember(dest => dest.ResourcePrices, act => act.MapFrom(src => src.ResourcePrices));

            CreateMap<JsonNode, NodeEntity> ();
            CreateMap<NodeLocation, NodeEntity>();
            CreateMap<Iface, IfaceEntity>();
            CreateMap<JsonNode, NodeEntity>();
        }
    }
}