using DataTransferObjects.NodeMon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.API.SignalR;

namespace WebUI.Server
{
    public class NodeService : INodesService
    {
        private readonly SignalRClient _NodeMonCon;

        public NodeService(SignalRClient NodeMonCon)
        {
            _NodeMonCon = NodeMonCon;
        }

        public async Task<List<NodeDto>> GetNodes()
        {
            return await _NodeMonCon.GetAllNodes();
        }
        public async Task<NodeDto> SingleNode(int id)
        {
            return await _NodeMonCon.GetSingleNode();
        }
        public async Task<bool> DeleteNode(string id)
        {
            return false;
        }
    }
}
