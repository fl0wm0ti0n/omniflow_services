using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Configuration.Annotations;

namespace DatabaseLib.Entities
{
    [Table("nodemon_NodeHistory")]
    public class NodeHistoryEntity
    {
        [Key]
        [Required]
        public int NodeHistoryEntityId { get; set; }
        [Required]
        public long Id { get; set; }
        [Required]
        public int? NodeEntityId { get; set; }
        [Required]
        public NodeEntity NodeEntity { get; set; }
        [Required]
        public string OsVersion { get; set; }
        [Required]
        public DateTime Updated { get; set; }
        [Required]
        [Column(TypeName = "bigint")]
        public TimeSpan Uptime { get; set; }
        public NodeLocationHistoryEntity Location { get; set; }
        public TotalResourcesHistoryEntity TotalResources { get; set; }
        public UsedResourcesHistoryEntity UsedResources { get; set; }
        public ReservedResourcesHistoryEntity ReservedResources { get; set; }
    }

    [Table("nodemon_NodeLocationHistory")]
    public class NodeLocationHistoryEntity
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
        [ForeignKey("NodeHistoryEntity")]
        public int NodeHistoryEntityId { get; set; }
        public NodeHistoryEntity NodeHistoryEntity { get; set; }
    }

    [Table("nodemon_TotalResourcesHistory")]
    public class TotalResourcesHistoryEntity
    {
        [Key]
        [Required]
        public int TotalResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
        [ForeignKey("NodeHistoryEntity")]
        public int NodeHistoryId { get; set; }
        public NodeHistoryEntity NodeHistory { get; set; }
    }

    [Table("nodemon_ReservedResourcesHistory")]
    public class ReservedResourcesHistoryEntity
    {
        [Key]
        [Required]
        public int ReservedResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
        [ForeignKey("NodeHistoryEntity")]
        public int NodeHistoryEntityId { get; set; }
        public NodeHistoryEntity NodeHistory { get; set; }
    }

    [Table("nodemon_UsedResourcesHistory")]
    public class UsedResourcesHistoryEntity
    {
        [Key]
        [Required]
        public int UsedResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
        [ForeignKey("NodeHistoryEntity")]
        public int NodeHistoryEntityId { get; set; }
        public NodeHistoryEntity NodeHistory { get; set; }
    }
}