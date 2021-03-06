using AutoMapper;
using DatabaseLib.Entities;
using Serilog;
using System.Threading.Tasks;
using DatabaseLib.Entities.GenericEntities;
using DatabaseLib.Entities.NodeMonEntities;
using DataTransferObjects.Models.NodeMon;
using NodeMonitor.Models;

namespace NodeMonitor.Business
{
    public class EntityToDto
    {
        private IMapper _mapper;

        public EntityToDto(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<FarmDto> FarmEntityTo(FarmEntity farm)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<FarmEntity, FarmDto>();
            //    cfg.CreateMap<FarmLocationEntity, FarmLocationDto>();
            //    cfg.CreateMap<WalletAddressEntity, WalletAddressDto>();
            //    cfg.CreateMap<ResourcePriceEntity, ReservedResourcesDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Farm with ID " + farm.FarmId.ToString());
            return _mapper.Map<FarmDto>(farm);
        }

        //
        // Speichert Node in Datenbank wenn NodeID noch nicht vorhanden
        //
        public async Task<NodeDto> NodeEntityToDto(NodeEntity node)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<NodeEntity, NodeDto>();
            //    cfg.CreateMap<NodeLocationEntity, NodeLocationDto>();
            //    cfg.CreateMap<TotalResourcesEntity, TotalResourcesDto>();
            //    cfg.CreateMap<ReservedResourcesEntity, ReservedResourcesDto>();
            //    cfg.CreateMap<UsedResourcesEntity, UsedResourcesDto>();
            //    cfg.CreateMap<WorkloadsEntity, WorkloadsDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Node with ID " + node.NodeId.ToString());
            return _mapper.Map<NodeDto>(node);
        }

        public async Task<AbonementEntity> AbonementEntityToDto(AbonementEntity abo)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<AbonementEntity, AbonementDto>();
            //    cfg.CreateMap<AbonementSourceTypEntity, AbonementSourceTypEntity>();
            //    cfg.CreateMap<AbonementTargetTypEntity, AbonementTargetTypDto>();
            //    cfg.CreateMap<AbonementsToSourcesEntity, AbonementsToSourcesDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Abo with Name " + abo.Name.ToString());
            return _mapper.Map<AbonementEntity>(abo);
        }

        public async Task<FarmerDto> FarmerEntityToDto(FarmerDto farmer)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<FarmerEntity, FarmerDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Farmer with Name" + farmer.Name.ToString());
            return _mapper.Map<FarmerDto>(farmer);
        }

        public async Task<SchedulesDto> SchedulesEntityToDto(SchedulesEntity schedules)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<NodeMonSchedulesEntity, NodeMonSchedulesDto>();
            //    cfg.CreateMap<NodeMonScheduleDaysEntity, NodeMonScheduleDaysDto>();
            //    cfg.CreateMap < NodeMonSchedulesToDaysEntity, NodeMonSchedulesToDaysDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Schedules with Name" + schedules.Name.ToString());
            return _mapper.Map<SchedulesDto>(schedules);
        }

        public async Task<ThreefoldApiUriDto> SchedulesEntityToDto(ThreefoldApiUriEntity uri)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ThreefoldApiUriEntity, ThreefoldApiUriDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map Uri with Name" + uri.Name.ToString());
            return _mapper.Map<ThreefoldApiUriDto>(uri);
        }

        public async Task<TokenHistoryDto> SchedulesEntityToDto(TokenHistoryDto token)
        {
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<TokenHistoryEntity, TokenHistoryDto>();
            //});
            //var mapper = new Mapper(config);
            Log.Information("Try to map TokenHistory with Wallet" + token.WalletAddress.ToString());
            return _mapper.Map<TokenHistoryDto>(token);
        }
    }
}