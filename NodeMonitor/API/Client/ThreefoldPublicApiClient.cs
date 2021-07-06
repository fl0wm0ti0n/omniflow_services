using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Models.CryptoTradeModels;
using Models.ThreeFoldModels;
using NodeMonitor.Protos;

namespace NodeMonitor.API.Client
{
    public class ThreefoldPublicApiClient : ApiClientBase, IThreefoldPublicApiClient
    {

        public async Task<List<JsonNode>> GetNodeListAsync()
        {
            List<JsonNode> returnobject = new List<JsonNode>();

            string UriString = "/explorer/nodes?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonNode>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public async Task<List<JsonFarm>> GetFarmListAsync()
        {
            List<JsonFarm> returnobject = new List<JsonFarm>();

            string UriString = "/explorer/farms?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonFarm>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public async Task<List<JsonUser>> GetUserListAsync()
        {
            List<JsonUser> returnobject = new List<JsonUser>();

            string UriString = "/explorer/users?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonUser>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public async Task<List<JsonWorkload>> GetWorkloadListAsync()
        {
            List<JsonWorkload> returnobject = new List<JsonWorkload>();

            string UriString = "/explorer/workloads?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonWorkload>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }
        public async Task<List<JsonReservation>> GetReservationListAsync()
        {
            List<JsonReservation> returnobject = new List<JsonReservation>();

            string UriString = "/explorer/reservations?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonReservation>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public async Task<List<JsonGateway>> GetGatewayListAsync()
        {
            List<JsonGateway> returnobject = new List<JsonGateway>();

            string UriString = "/explorer/gateways?page=";

            int i = 1;
            while (true)
            {
                string finalUriString = UriString + i;
                HttpResponseMessage response = await Client.GetAsync(finalUriString);
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength <= 5)
                    {
                        returnobject.AddRange(await response.Content.ReadFromJsonAsync<List<JsonGateway>>() ?? null);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            return returnobject;
        }

        public async Task<JsonNode> GetUniqueNodeAsync(string nodeId)
        {
            JsonNode customer = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/nodes/{ nodeId }");
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadFromJsonAsync<JsonNode>();
            }
            return customer;
        }

        public async Task<JsonFarm> GetUniqueFarmAsync(string farmId)
        {
            JsonFarm returnobject = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/farms/{ farmId }");
            if (response.IsSuccessStatusCode)
            {
                returnobject = await response.Content.ReadFromJsonAsync<JsonFarm>();
            }
            return returnobject;
        }

        public async Task<JsonUser> GetUniqueUserAsync(string userId)
        {
            JsonUser returnobject = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/users/{ userId }");
            if (response.IsSuccessStatusCode)
            {
                returnobject = await response.Content.ReadFromJsonAsync<JsonUser>();
            }
            return returnobject;
        }

        public async Task<JsonWorkload> GetUniqueWorkloadAsync(string workloadId)
        {
            JsonWorkload returnobject = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/workloads/{ workloadId }");
            if (response.IsSuccessStatusCode)
            {
                returnobject = await response.Content.ReadFromJsonAsync<JsonWorkload>();
            }
            return returnobject;
        }

        public async Task<JsonReservation> GetUniqueReservationAsync(string reservationId)
        {
            JsonReservation returnobject = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/reservations/{ reservationId }");
            if (response.IsSuccessStatusCode)
            {
                returnobject = await response.Content.ReadFromJsonAsync<JsonReservation>();
            }
            return returnobject;
        }

        public async Task<JsonGateway> GetUniqueGatewayAsync(string gatewayId)
        {
            JsonGateway returnobject = null;
            HttpResponseMessage response = await Client.GetAsync($"/explorer/gateways/{ gatewayId }");
            if (response.IsSuccessStatusCode)
            {
                returnobject = await response.Content.ReadFromJsonAsync<JsonGateway>();
            }
            return returnobject;
        }
    }
}