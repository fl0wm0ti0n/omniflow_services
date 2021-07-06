using System.Collections.Generic;
using DataTransferObjects.Models.NodeMon;

namespace NodeMonitor.Controller
{
    public interface IDtoTransferController
    {
        List<NodeDto> SendAllNodesCont();
    }
}