using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace DatabaseLib.Entities.NodeMonEntities
{
    [Table("nodemon_Farm")]
    public class FarmEntity
    {
        [Key]
        [Required]
        public int FarmEntityId { get; set; }
        [Required]
        public long FarmId { get; set; }
        public long? ThreebotId { get; set; }
        public string IyoOrganization { get; set; }
        public string Name { get; set; }
        public FarmLocationEntity Location { get; set; }
        public string Email { get; set; }
        public string PrefixZero { get; set; }
        public ICollection<WalletAddressEntity> WalletAddresses { get; set; }
        public ICollection<ResourcePriceEntity> ResourcePrices { get; set; }
        public ICollection<NodeEntity> Nodes { get; set; }
    }

    [Table("nodemon_FarmLocation")]
    public class FarmLocationEntity
    {
        [Key]
        [Required]
        public int FarmLocationId { get; set; }
        [Required]
        public string City_farm { get; set; }
        [Required]
        public string Country_farm { get; set; }
        [Required]
        public string Continent_farm { get; set; }
        [Required]
        public long Latitude_farm { get; set; }
        [Required]
        public long Longitude_farm { get; set; }
        public int FarmEntityId { get; set; }
        public FarmEntity FarmEntity { get; set; }
    }

    [Table("nodemon_WalletAddress")]
    public class WalletAddressEntity
    {
        [Key]
        [Required]
        public int WalletAddressId { get; set; }
        [Required]
        public string Asset { get; set; }
        [Required]
        public string Address { get; set; }
        public int? TokenHistoryEntityId { get; set; }
        public TokenHistoryEntity TokenHistoryEntity { get; set; }
        public int? FarmEntityId { get; set; }
        public FarmEntity FarmEntity { get; set; }
    }

    [Table("nodemon_ResourcePrice")]
    public class ResourcePriceEntity
    {
        [Key]
        [Required]
        public int ResourcePriceId { get; set; }
        public long Currency { get; set; }
        public long Cru { get; set; }
        public long Mru { get; set; }
        public long Hru { get; set; }
        public long Sru { get; set; }
        public long Nru { get; set; }
        public int FarmEntityId { get; set; }
        public FarmEntity FarmEntity { get; set; }
    }
}
