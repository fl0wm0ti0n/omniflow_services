using DataTransferObjects.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects.Models.NodeMon;

namespace InterfacesLib
{
    public interface ISignalRClient
    {
        // Send singles
        Task SendAsync(string message, string connectionId);
        Task SendAsync(string message);
        Task SendSingleNode(NodeDto node);
        Task SendSingleFarm(FarmDto farm);
        //Task OnConnectedAsync();
        //Task OnDisconnectedAsync(Exception e);
        // Send Lists
        Task SendNodeList(List<NodeDto> nodes);
        Task SendFarmList(List<FarmDto> farm);
        Task SendSettingList(List<SettingsDto> settings);
        //Task SendScheduleList(List<NodeMonSchedulesDto> schedules);

        // to something
        //Task SaveSchedule(NodeMonSchedulesDto schedule);
        //Task SaveSetting(SettingsDto schedule);

        // Get something
        Task<List<NodeDto>> GetAllNodes();
        Task<NodeDto> GetSingleNode(int id);
        Task<List<FarmDto>> GetAllFarms();
        Task<FarmDto> GetSingleFarm(int id);
    }
}
