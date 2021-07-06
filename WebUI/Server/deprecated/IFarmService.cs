using DataTransferObjects.NodeMon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Server
{
    public interface IFarmService
    {
        Task<List<FarmDto>> GetFarms();
        Task<bool> CreateFarm(FarmDto farm);
        Task<bool> EditFarm(string id, FarmDto farm);
        Task<FarmDto> SingleFarm(string id);
        Task<bool> DeleteFarm(string id);
    }
}