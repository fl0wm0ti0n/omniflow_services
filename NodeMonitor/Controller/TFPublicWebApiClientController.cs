using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Models.ThreeFoldModels;
using NodeMonitor.API.Client;

namespace NodeMonitor.Controller
{
    public class TFPublicWebApiClientController : ITFPublicWebApiClientController
    {
        private IThreefoldPublicApiClient _threefoldPublicApiClient;
        public TFPublicWebApiClientController(IThreefoldPublicApiClient threefoldPublicApiClient)
        {
            _threefoldPublicApiClient = threefoldPublicApiClient;
        }

        public async Task<List<JsonNode>> GetNodeListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetNodeListAsync();
            return returnobject;
        }

        public async Task<List<JsonFarm>> GetFarmListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetFarmListAsync();
            return returnobject;
        }

        public async Task<List<JsonUser>> GetUserListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUserListAsync();
            return returnobject;
        }

        public async Task<List<JsonWorkload>> GetWorkloadListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetWorkloadListAsync();
            return returnobject;
        }
        public async Task<List<JsonReservation>> GetReservationListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetReservationListAsync();
            return returnobject;
        }

        public async Task<List<JsonGateway>> GetGatewayListAsync()
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetGatewayListAsync();
            return returnobject;
        }

        public async Task<JsonNode> GetUniqueNodeAsync(string nodeId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueNodeAsync(nodeId);
            return returnobject;
        }

        public async Task<JsonFarm> GetUniqueFarmAsync(string farmId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueFarmAsync(farmId);
            return returnobject;
        }

        public async Task<JsonUser> GetUniqueUserAsync(string userId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueUserAsync(userId);
            return returnobject;
        }

        public async Task<JsonWorkload> GetUniqueWorkloadAsync(string workloadId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueWorkloadAsync(workloadId);
            return returnobject;
        }

        public async Task<JsonReservation> GetUniqueReservationAsync(string reservationId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueReservationAsync(reservationId);
            return returnobject;
        }

        public async Task<JsonGateway> GetUniqueGatewayAsync(string gatewayId)
        {
            // TODO Contitions // Settings?
            var returnobject = await _threefoldPublicApiClient.GetUniqueGatewayAsync(gatewayId);
            return returnobject;
        }
    }
}