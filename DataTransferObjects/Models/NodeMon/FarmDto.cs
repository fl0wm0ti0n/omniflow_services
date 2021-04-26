using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects.NodeMon
{
    public class FarmDto
    {
        [MaxLength(50)]
        public int FarmEntityId { get; set; }
        [MaxLength(50)]
        public long FarmId { get; set; }
        [MaxLength(50)]
        public long? ThreebotId { get; set; }
        [MaxLength(50)]
        public string IyoOrganization { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public FarmLocationDto Location { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string PrefixZero { get; set; }
        public ICollection<WalletAddressDto> WalletAddresses { get; set; }
        public ICollection<ResourcePriceDto> ResourcePrices { get; set; }
        public ICollection<NodeDto> Nodes { get; set; }
    }

    public class FarmLocationDto
    {
        [MaxLength(50)]
        public int FarmLocationId { get; set; }
        [MaxLength(50)]
        public string City_farm { get; set; }
        [MaxLength(50)]
        public string Country_farm { get; set; }
        [MaxLength(50)]
        public string Continent_farm { get; set; }
        [MaxLength(50)]
        public long Latitude_farm { get; set; }
        [MaxLength(50)]
        public long Longitude_farm { get; set; }
    }

    public class WalletAddressDto
    {
        [MaxLength(50)]
        public int WalletAddressId { get; set; }
        [MaxLength(50)]
        public string Asset { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
    }

    public class ResourcePriceDto
    {
        [MaxLength(50)]
        public int ResourcePriceId { get; set; }
        [MaxLength(20)]
        public long Currency { get; set; }
        [MaxLength(20)]
        public long Cru { get; set; }
        [MaxLength(20)]
        public long Mru { get; set; }
        [MaxLength(20)]
        public long Hru { get; set; }
        [MaxLength(20)]
        public long Sru { get; set; }
        [MaxLength(20)]
        public long Nru { get; set; }
    }
}
