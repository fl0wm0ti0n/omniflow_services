using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.ThreeFoldModels;

namespace NodeMonitor.Controller
{
    public interface ITFPublicWebApiClientController
    {
        Task<List<JsonNode>> GetNodeListAsync();
        Task<List<JsonFarm>> GetFarmListAsync();
        Task<List<JsonUser>> GetUserListAsync();
        Task<List<JsonWorkload>> GetWorkloadListAsync();
        Task<List<JsonReservation>> GetReservationListAsync();
        Task<List<JsonGateway>> GetGatewayListAsync();
        Task<JsonNode> GetUniqueNodeAsync(string nodeId);
        Task<JsonFarm> GetUniqueFarmAsync(string farmId);
        Task<JsonUser> GetUniqueUserAsync(string userId);
        Task<JsonWorkload> GetUniqueWorkloadAsync(string workloadId);
        Task<JsonReservation> GetUniqueReservationAsync(string reservationId);
        Task<JsonGateway> GetUniqueGatewayAsync(string gatewayId);
    }
}
