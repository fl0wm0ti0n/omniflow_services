using AutoMapper;
using NUnit.Framework;
using NodeMonitor;
using DatabaseLib.Entities;
using DataTransferObjects.NodeMon;

namespace NodeMonitor.Tests
{
    [TestFixture]
    public class AutoMapperTests
    {
        public MapperConfiguration configuration;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_MapperConfig()
        {
            configuration = new MapperConfiguration(cfg =>

            //#########################################
            // Map from Entities to Dto's             #
            //#########################################
            {
                // Farm Map
                cfg.CreateMap<FarmEntity, FarmDto>();
                cfg.CreateMap<FarmLocationEntity, FarmLocationDto>();
                cfg.CreateMap<WalletAddressEntity, WalletAddressDto>();
                cfg.CreateMap<ResourcePriceEntity, ResourcePriceDto>();

                // Node Map
                cfg.CreateMap<NodeEntity, NodeDto>();
                cfg.CreateMap<NodeLocationEntity, NodeLocationDto>();
                cfg.CreateMap<TotalResourcesEntity, TotalResourcesDto>();
                cfg.CreateMap<ReservedResourcesEntity, ReservedResourcesDto>();
                cfg.CreateMap<UsedResourcesEntity, UsedResourcesDto>();
                cfg.CreateMap<WorkloadsEntity, WorkloadsDto>();
                cfg.CreateMap<PublicConfigEntity, PublicConfigDto>();
                cfg.CreateMap<IfaceEntity, IfaceDto>();

                // NodeHistory Map
                cfg.CreateMap<NodeHistoryEntity, NodeHistoryDto>();
                cfg.CreateMap<NodeLocationHistoryEntity, NodeLocationHistoryDto>();
                cfg.CreateMap<TotalResourcesHistoryEntity, TotalResourcesHistoryDto>();
                cfg.CreateMap<ReservedResourcesHistoryEntity, ReservedResourcesHistoryDto>();
                cfg.CreateMap<UsedResourcesHistoryEntity, UsedResourcesHistoryDto>();

                // Abonement Map
                cfg.CreateMap<AbonementEntity, AbonementDto>();
                cfg.CreateMap<AbonementSourceTypEntity, AbonementSourceTypDto>();
                cfg.CreateMap<AbonementTargetTypEntity, AbonementTargetTypDto>();
                cfg.CreateMap<AbonementsToSourcesEntity, AbonementsToSourcesDto>();

                // Farmer Map
                cfg.CreateMap<FarmerEntity, FarmerDto>();

                // Schedules Map
                cfg.CreateMap<NodeMonSchedulesEntity, NodeMonSchedulesDto>();
                cfg.CreateMap<NodeMonScheduleDaysEntity, NodeMonScheduleDaysDto>();
                cfg.CreateMap<NodeMonSchedulesToDaysEntity, NodeMonSchedulesToDaysDto>();

                // Uri Map
                cfg.CreateMap<ThreefoldApiUriEntity, ThreefoldApiUriDto>();

                // TokenHistory Map
                cfg.CreateMap<TokenHistoryEntity, TokenHistoryDto>();

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
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}