using DataTransferObjects.NodeMon;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Server
{
    public interface INodesService
    {
        Task<List<NodeDto>> GetNodes();
        Task<NodeDto> SingleNode(string id);
        Task<bool> DeleteNode(string id);
    }
}