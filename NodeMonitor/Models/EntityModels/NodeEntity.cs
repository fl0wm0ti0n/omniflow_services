using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DatabaseLib.Models.JsonModels;

namespace DatabaseLib.Models.EntityModels
{
    [Table("nodemon_Node")]
    public partial class NodeEntity
    {
        [Key]
        [Required]
        public int NodeEntityId { get; set; }
        [Required]
        public long Id { get; set; }
        [Required]
        public string NodeId { get; set; }
        public string NodeIdV1 { get; set; }
        [Required]
        public long FarmId { get; set; }
        public int? FarmEntityId { get; set; }
        public FarmEntity FarmEntity { get; set; }
        public string OsVersion { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Uptime { get; set; }
        public string Address { get; set; }
        public NodeLocationEntity NodeLocation { get; set; }
        public ResourcesEntity TotalResources { get; set; }
        public ResourcesEntity ReservedResources { get; set; }
        public ResourcesEntity UsedResources { get; set; }
        public WorkloadsEntity Workloads { get; set; }
        public string Proofs { get; set; }
        public ICollection<IfaceEntity> Interfaces { get; set; }
        public string PublicConfig { get; set; }
        public bool FreeToUse { get; set; }
        public bool Approved { get; set; }
        public string PublicKeyHex { get; set; }
        public string WgPorts { get; set; }
        public ICollection<TokenHistoryEntity> TokenHistory { get; set; }
        public ICollection<NodeHistoryEntity> NodeHistory { get; set; }
    }

    [Table("nodemon_Iface")]
    public class IfaceEntity
    {
        [Key]
        [Required]
        public int IfaceId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<AddrsEntity> Addrs { get; set; }
        public ICollection<GatewayEntity> Gateway { get; set; }
        [Required]
        public string Macaddress { get; set; }
        public int NodeEntityId { get; set; }
        public NodeEntity NodeEntity { get; set; }
    }

    [Table("nodemon_Addrs")]
    public class AddrsEntity
    {
        [Key]
        [Required]
        public int AddrsEntityId { get; set; }
        public string Address { get; set; }
        public int IfaceId { get; set; }
        public IfaceEntity IfaceEntity { get; set; }
    }

    [Table("nodemon_Gateway")]
    public class GatewayEntity
    {
        [Key]
        [Required]
        public int GatewayEntityId { get; set; }
        public string Address { get; set; }
        public int IfaceId { get; set; }
        public IfaceEntity IfaceEntity { get; set; }
    }

    [Table("nodemon_NodeLocation")]
    public class NodeLocationEntity
    {
        [Key]
        [Required]
        public int NodeLocationId { get; set; }
        [Required]
        public string CityNode { get; set; }
        [Required]
        public string CountryNode { get; set; }
        [Required]
        public string ContinentNode { get; set; }
        [Required]
        public double LatitudeNode { get; set; }
        [Required]
        public double LongitudeNode { get; set; }
        [Required]
        [ForeignKey("NodeEntity")]
        public int NodeEntityId { get; set; }
        public NodeEntity NodeEntity { get; set; }
    }

    [Table("nodemon_Resources")]
    public class ResourcesEntity
    {
        [Key]
        [Required]
        public int ResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
        [ForeignKey("NodeEntity")]
        public int? NodeEntityId { get; set; }
        public NodeEntity NodeEntity { get; set; }
        [ForeignKey("NodeHistoryEntity")]
        public int? NodeHistoryId { get; set; }
        public NodeHistoryEntity NodeHistory { get; set; }
    }

   //[Table("nodemon_TotalResources")]
   //public class TotalResourcesEntity
   //{
   //    [Key]
   //    [Required]
   //    public int TotalResourcesId { get; set; }
   //    public long Cru { get; set; }
   //    public long Mru { get; set; }
   //    public long Hru { get; set; }
   //    public long Sru { get; set; }
   //    [ForeignKey("NodeEntity")]
   //    public int? NodeEntityId { get; set; }
   //    public NodeEntity NodeEntity { get; set; }
   //    [ForeignKey("NodeHistoryEntity")]
   //    public int? NodeHistoryId { get; set; }
   //    public NodeHistoryEntity NodeHistory { get; set; }
   //}
   //
   //[Table("nodemon_ReservedResources")]
   //public class ReservedResourcesEntity
   //{
   //    [Key]
   //    [Required]
   //    public int ReservedResourcesId { get; set; }
   //    public long Cru { get; set; }
   //    public long Mru { get; set; }
   //    public long Hru { get; set; }
   //    public long Sru { get; set; }
   //    [ForeignKey("NodeEntity")]
   //    public int? NodeEntityId { get; set; }
   //    public NodeEntity NodeEntity { get; set; }
   //    [ForeignKey("NodeHistoryEntity")]
   //    public int? NodeHistoryEntityId { get; set; }
   //    public NodeHistoryEntity NodeHistory { get; set; }
   //}
   //
   //[Table("nodemon_UsedResources")]
   //public class UsedResourcesEntity
   //{
   //    [Key]
   //    [Required]
   //    public int UsedResourcesId { get; set; }
   //    public long Cru { get; set; }
   //    public long Mru { get; set; }
   //    public long Hru { get; set; }
   //    public long Sru { get; set; }
   //    [ForeignKey("NodeEntity")]
   //    public int? NodeEntityId { get; set; }
   //    public NodeEntity NodeEntity { get; set; }
   //    [ForeignKey("NodeHistoryEntity")]
   //    public int? NodeHistoryEntityId { get; set; }
   //    public NodeHistoryEntity NodeHistory { get; set; }
   //}

    [Table("nodemon_Workloads")]
    public class WorkloadsEntity
    {
        [Key]
        [Required]
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
        [ForeignKey("NodeEntity")]
        public int NodeEntityId { get; set; }
        public NodeEntity NodeEntity { get; set; }
    }

    public partial class NodeEntity
    {
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static DateTime SecondsToDateTime(long secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);

            string answer = string.Format("{0:D2}h:{1:D2}h:{2:D2}m:{3:D2}s:{4:D3}ms",
                t.Days,
                t.Hours,
                t.Minutes,
                t.Seconds,
                t.Milliseconds);

            return Convert.ToDateTime(answer);
        }
    }
}