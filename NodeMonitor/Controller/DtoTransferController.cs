using AutoMapper;
using InterfacesLib;
using NodeMonitor.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObjects.Generic;
using DataTransferObjects.Models.NodeMon;


namespace NodeMonitor.Controller
{
    public class DtoTransferController : IDtoTransferController
    {
        private readonly IMapper _mapper;

        public DtoTransferController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<NodeDto> SendAllNodesCont()
        {
            using (var _dbContext = new nmDBContext())
            {
                try
                {
                    Log.Information("Try to map Nodes");
                    var nodes = _mapper.Map<List<NodeDto>>(_dbContext.Nodes.ToList());
                    return nodes;
                }
                catch (Exception e)
                {
                    Log.Information("An Error occured by trying to map Nodes {0}", e);
                    return null;
                }
            }
        }
    }
}
