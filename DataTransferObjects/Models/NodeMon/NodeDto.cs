using System;
using System.Collections.Generic;

namespace DataTransferObjects.NodeMon
{
    public partial class NodeDto
    {
        public int NodeEntityId { get; set; }
        public long Id { get; set; }
        public string NodeId { get; set; }
        public string NodeIdV1 { get; set; }
        public long FarmId { get; set; }
        public FarmDto FarmEntity { get; set; }
        public string OsVersion { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public TimeSpan Uptime { get; set; }
        public string Address { get; set; }
        public NodeLocationDto Location { get; set; }
        public TotalResourcesDto TotalResources { get; set; }
        public ReservedResourcesDto ReservedResources { get; set; }
        public UsedResourcesDto UsedResources { get; set; }
        public PublicConfigDto PublicConfigs { get; set; }
        public WorkloadsDto Workloads { get; set; }
        public string Proofs { get; set; }
        public ICollection<IfaceDto> Interfaces { get; set; }
        public bool FreeToUse { get; set; }
        public bool Approved { get; set; }
        public string PublicKeyHex { get; set; }
        public string WgPorts { get; set; }
        public ICollection<TokenHistoryDto> TokenHistory { get; set; }
        public ICollection<NodeHistoryDto> NodeHistory { get; set; }
    }

    public class IfaceDto
    {
        public int IfaceId { get; set; }
        public string Name { get; set; }
        public string Addrs { get; set; }
        public string Gateway { get; set; }
        public string Macaddress { get; set; }
    }

    public class NodeLocationDto
    {
        public int NodeLocationId { get; set; }
        public string CityNode { get; set; }
        public string CountryNode { get; set; }
        public string ContinentNode { get; set; }
        public double LatitudeNode { get; set; }
        public double LongitudeNode { get; set; }
    }

   public class TotalResourcesDto
   {
       public int TotalResourcesId { get; set; }
       public long Cru { get; set; }
       public long Mru { get; set; }
       public long Hru { get; set; }
       public long Sru { get; set; }
   }
   
   public class ReservedResourcesDto
   {
       public int ReservedResourcesId { get; set; }
       public long Cru { get; set; }
       public long Mru { get; set; }
       public long Hru { get; set; }
       public long Sru { get; set; }
    }
   
   public class UsedResourcesDto
   {
       public int UsedResourcesId { get; set; }
       public long Cru { get; set; }
       public long Mru { get; set; }
       public long Hru { get; set; }
       public long Sru { get; set; }
    }

    public class PublicConfigDto
    {
        public int PublicConfigEntityId { get; set; }
        public string Master { get; set; }
        public long Type { get; set; }
        public string Ipv4 { get; set; }
        public string Ipv6 { get; set; }
        public string Gw4 { get; set; }
        public string Gw6 { get; set; }
        public long Version { get; set; }
        public int? NodeEntityId { get; set; }
    }

    public class WorkloadsDto
    {
        public int WorkloadsEntityId { get; set; }
        public long Network { get; set; }
        public long Volume { get; set; }
        public long ZdbNamespace { get; set; }
        public long Container { get; set; }
        public long K8SVm { get; set; }
        public long Proxy { get; set; }
        public long ReverseProxy { get; set; }
        public long Subdomain { get; set; }
        public long DelegateDomain { get; set; }
    }
}