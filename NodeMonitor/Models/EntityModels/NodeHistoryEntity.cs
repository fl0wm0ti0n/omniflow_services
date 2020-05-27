using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLib.Models.EntityModels
{
    [Table("nodemon_NodeHistory")]
    public class NodeHistoryEntity
    {
        [Key]
        [Required]
        public int NodeHistoryEntityId { get; set; }
        [Required]
        public int NodeEntityId { get; set; }
        [Required]
        public NodeEntity NodeEntity { get; set; }
        [Required]
        public string OsVersion { get; set; }
        [Required]
        [Timestamp]
        public DateTime Updated { get; set; }
        [Required]
        [Timestamp]
        public DateTime Uptime { get; set; }
        public ResourcesEntity TotalResources { get; set; }
        //public TotalResourcesEntity TotalResources { get; set; }
        //public ReservedResourcesEntity ReservedResources { get; set; }
        //public UsedResourcesEntity UsedResources { get; set; }
    }
}