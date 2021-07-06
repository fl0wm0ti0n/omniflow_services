using AutoMapper;
using DatabaseLib.Entities.GenericEntities;
using DatabaseLib.Entities.NodeMonEntities;
using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObjects.Generic;
using DataTransferObjects.Models.NodeMon;

namespace NodeMonitor
{
    public class MapperConfig : Profile
    {
        //private readonly nmDBContext _context;

        public MapperConfig()
        {
            //#########################################
            // Map from Entities to Dto's             #
            //#########################################
            // Farm Map
            CreateMap<FarmEntity, FarmDto>().ReverseMap();
            CreateMap<FarmLocationEntity, FarmLocationDto>().ReverseMap();
            CreateMap<WalletAddressEntity, WalletAddressDto>().ReverseMap();
            CreateMap<ResourcePriceEntity, ResourcePriceDto>().ReverseMap();

            // Node Map
            CreateMap<NodeEntity, NodeDto>().ReverseMap();
            CreateMap<NodeLocationEntity, NodeLocationDto>().ReverseMap();
            CreateMap<TotalResourcesEntity, TotalResourcesDto>().ReverseMap();
            CreateMap<ReservedResourcesEntity, ReservedResourcesDto>().ReverseMap();
            CreateMap<UsedResourcesEntity, UsedResourcesDto>().ReverseMap();
            CreateMap<WorkloadsEntity, WorkloadsDto>().ReverseMap();
            CreateMap<PublicConfigEntity, PublicConfigDto>().ReverseMap();
            CreateMap<IfaceEntity, IfaceDto>().ReverseMap();

            // NodeHistory Map
            CreateMap<NodeHistoryEntity, NodeHistoryDto>().ReverseMap();
            CreateMap<NodeLocationHistoryEntity, NodeLocationHistoryDto>().ReverseMap();
            CreateMap<TotalResourcesHistoryEntity, TotalResourcesHistoryDto>().ReverseMap();
            CreateMap<ReservedResourcesHistoryEntity, ReservedResourcesHistoryDto>().ReverseMap();
            CreateMap<UsedResourcesHistoryEntity, UsedResourcesHistoryDto>().ReverseMap();

            // Abonement Map
            CreateMap<AbonementEntity, AbonementDto>().ReverseMap();
            CreateMap<AbonementSourceTypEntity, AbonementSourceTypDto>().ReverseMap();
            CreateMap<AbonementTargetTypEntity, AbonementTargetTypDto>().ReverseMap();
            CreateMap<AbonementsToSourcesEntity, AbonementsToSourcesDto>().ReverseMap();

            // Farmer Map
            CreateMap<FarmerEntity, FarmerDto>().ReverseMap();

            // Schedules Map
            CreateMap<SchedulesEntity, SchedulesDto>().ReverseMap();
            CreateMap<ScheduleDaysEntity, ScheduleDaysDto>().ReverseMap();
            CreateMap<SchedulesToDaysEntity, SchedulesToDaysDto>().ReverseMap();
            CreateMap<ScheduleTaskEntity, ScheduleTaskDto>().ReverseMap();
            CreateMap<ScheduleTaskTypEntity, ScheduleTaskTypDto>().ReverseMap();
            CreateMap<ScheduleTriggerEntity, ScheduleTriggerDto>().ReverseMap();
            CreateMap<ScheduleTriggerTypEntity, ScheduleTriggerTypDto>().ReverseMap();

            //User Map
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserDeviceEntity, UserDeviceDto>().ReverseMap();
            CreateMap<UserLocationEntity, UserLocationDto>().ReverseMap();
            CreateMap<DeviceTypEntity, DeviceTypDto>().ReverseMap();

            // Uri Map
            CreateMap<ThreefoldApiUriEntity, ThreefoldApiUriDto>().ReverseMap();

            // TokenHistory Map
            CreateMap<TokenHistoryEntity, TokenHistoryDto>().ReverseMap();
        }
    }
}