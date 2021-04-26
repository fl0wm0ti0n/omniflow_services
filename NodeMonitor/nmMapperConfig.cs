using AutoMapper;
using DatabaseLib.Entities;
using DataTransferObjects.NodeMon;
using System;
using System.Collections.Generic;
using System.Text;

namespace NodeMonitor
{
    public class nmMapperConfig : Profile
    {
        //private readonly nmDBContext _context;

        public nmMapperConfig()
        {
            //#########################################
            // Map from Entities to Dto's             #
            //#########################################
                    // Farm Map
                CreateMap<FarmEntity, FarmDto>();
                CreateMap<FarmLocationEntity, FarmLocationDto>();
                CreateMap<WalletAddressEntity, WalletAddressDto>();
                CreateMap<ResourcePriceEntity, ResourcePriceDto>();

                // Node Map
                CreateMap<NodeEntity, NodeDto>();
                CreateMap<NodeLocationEntity, NodeLocationDto>();
                CreateMap<TotalResourcesEntity, TotalResourcesDto>();
                CreateMap<ReservedResourcesEntity, ReservedResourcesDto>();
                CreateMap<UsedResourcesEntity, UsedResourcesDto>();
                CreateMap<WorkloadsEntity, WorkloadsDto>();
                CreateMap<PublicConfigEntity, PublicConfigDto>();
                CreateMap<IfaceEntity, IfaceDto>();

                // NodeHistory Map
                CreateMap<NodeHistoryEntity, NodeHistoryDto>();
                CreateMap<NodeLocationHistoryEntity, NodeLocationHistoryDto>();
                CreateMap<TotalResourcesHistoryEntity, TotalResourcesHistoryDto>();
                CreateMap<ReservedResourcesHistoryEntity, ReservedResourcesHistoryDto>();
                CreateMap<UsedResourcesHistoryEntity, UsedResourcesHistoryDto>();

                // Abonement Map
                CreateMap<AbonementEntity, AbonementDto>();
                CreateMap<AbonementSourceTypEntity, AbonementSourceTypDto>();
                CreateMap<AbonementTargetTypEntity, AbonementTargetTypDto>();
                CreateMap<AbonementsToSourcesEntity, AbonementsToSourcesDto>();

                // Farmer Map
                CreateMap<FarmerEntity, FarmerDto>();

                // Schedules Map
                CreateMap<NodeMonSchedulesEntity, NodeMonSchedulesDto>();
                CreateMap<NodeMonScheduleDaysEntity, NodeMonScheduleDaysDto>();
                CreateMap<NodeMonSchedulesToDaysEntity, NodeMonSchedulesToDaysDto>();

                // Uri Map
                CreateMap<ThreefoldApiUriEntity, ThreefoldApiUriDto>();

                // TokenHistory Map
                CreateMap<TokenHistoryEntity, TokenHistoryDto>();

                //#########################################
                // Map from Dto's to Entities             #
                //#########################################
                // // Farm Map
                // cfg.CreateMap<FarmEntity, FarmDto>().ReverseMap();
                // cfg.CreateMap<FarmLocationEntity, FarmLocationDto>().ReverseMap();
                // cfg.CreateMap<WalletAddressEntity, WalletAddressDto>().ReverseMap();
                // cfg.CreateMap<ResourcePriceEntity, ReservedResourcesDto>().ReverseMap();
                //
                // // Node Map
                // cfg.CreateMap<NodeEntity, NodeDto>().ReverseMap();
                // cfg.CreateMap<NodeLocationEntity, NodeLocationDto>().ReverseMap();
                // cfg.CreateMap<TotalResourcesEntity, TotalResourcesDto>().ReverseMap();
                // cfg.CreateMap<ReservedResourcesEntity, ReservedResourcesDto>().ReverseMap();
                // cfg.CreateMap<UsedResourcesEntity, UsedResourcesDto>().ReverseMap();
                // cfg.CreateMap<WorkloadsEntity, WorkloadsDto>().ReverseMap();
                //
                // // Abonement Map
                // cfg.CreateMap<AbonementEntity, AbonementDto>().ReverseMap();
                // cfg.CreateMap<AbonementSourceTypEntity, AbonementSourceTypEntity>().ReverseMap();
                // cfg.CreateMap<AbonementTargetTypEntity, AbonementTargetTypDto>().ReverseMap();
                // cfg.CreateMap<AbonementsToSourcesEntity, AbonementsToSourcesDto>().ReverseMap();
                //
                // // Farmer Map
                // cfg.CreateMap<FarmerEntity, FarmerDto>().ReverseMap();
                //
                // // Schedules Map
                // cfg.CreateMap<NodeMonSchedulesEntity, NodeMonSchedulesDto>().ReverseMap();
                // cfg.CreateMap<NodeMonScheduleDaysEntity, NodeMonScheduleDaysDto>().ReverseMap();
                // cfg.CreateMap<NodeMonSchedulesToDaysEntity, NodeMonSchedulesToDaysDto>().ReverseMap();
                //
                // // Uri Map
                // cfg.CreateMap<ThreefoldApiUriEntity, ThreefoldApiUriDto>().ReverseMap();
                //
                // // TokenHistory Map
                // cfg.CreateMap<TokenHistoryEntity, TokenHistoryDto>().ReverseMap();
                //
                // //#########################################
                // // Map from Json to Entities              #
                // //#########################################
        }
    }
}
