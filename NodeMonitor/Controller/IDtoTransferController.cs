using DataTransferObjects.NodeMon;
using System.Collections.Generic;

namespace NodeMonitor.Controller
{
    public interface IDtoTransferController
    {
        List<NodeDto> SendAllNodesCont();
    }
}