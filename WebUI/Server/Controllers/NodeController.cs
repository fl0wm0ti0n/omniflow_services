using DataTransferObjects.NodeMon;
using InterfacesLib;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private ISignalRClient _sigr;

        public NodeController(ISignalRClient sigr)
        {
            _sigr = sigr;
        }

        [HttpGet]
        [Route("all")]
        public Task<List<NodeDto>> GetNodes()
        {
            return _sigr.GetAllNodes();
        }

        [HttpPost]
        public void Post(NodeDto node)
        {
            //TODO
        }
    }
}