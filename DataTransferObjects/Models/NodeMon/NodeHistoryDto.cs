using System;
using System.Collections.Generic;

namespace DataTransferObjects.Models.NodeMon
{
    public class NodeHistoryDto
    {
        public int NodeHistoryEntityId { get; set; }
        public long Id { get; set; }
        public int? NodeEntityId { get; set; }
        public string OsVersion { get; set; }
        public DateTime Updated { get; set; }
        public TimeSpan Uptime { get; set; }
        public NodeLocationHistoryDto Location { get; set; }
        public TotalResourcesHistoryDto TotalResources { get; set; }
        public ReservedResourcesHistoryDto ReservedResources { get; set; }
        public UsedResourcesHistoryDto UsedResources { get; set; }
    }

    public class NodeLocationHistoryDto
    {
        public int NodeLocationId { get; set; }
        public string CityNode { get; set; }
        public string CountryNode { get; set; }
        public string ContinentNode { get; set; }
        public double LatitudeNode { get; set; }
        public double LongitudeNode { get; set; }
    }

    public class TotalResourcesHistoryDto
    {
        public int TotalResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
    }

    public class ReservedResourcesHistoryDto
    {
        public int ReservedResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
    }

    public class UsedResourcesHistoryDto
    {
        public int UsedResourcesId { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
    }
}