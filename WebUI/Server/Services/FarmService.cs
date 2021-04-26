using DataTransferObjects.NodeMon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.API.SignalR;

namespace WebUI.Server
{
    public class FarmService : IFarmService
    {
        private readonly SignalRClient _FarmMonCon;

        public FarmService(SignalRClient FarmMonCon)
        {
            _FarmMonCon = FarmMonCon;
        }

        public async Task<List<FarmDto>> GetFarms()
        {
            return await _FarmMonCon.GetAllFarms();
        }
        public async Task<FarmDto> SingleFarm(string id)
        {
            return await _FarmMonCon.GetSingleFarm();
        }
        public async Task<bool> DeleteFarm(string id)
        {
            return false;
        }
        public async Task<bool> CreateFarm(FarmDto farm)
        {
            return false;
        }
        public async Task<bool> EditFarm(string id, FarmDto farm)
        {
            return false;
        }
    }
}
