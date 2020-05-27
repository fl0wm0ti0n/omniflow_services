using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLib.Models.EntityModels
{
    [Table("nodemon_Farmer")]
    public class FarmerEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public long ThreebotId { get; set; }
        [Required]
        public string IyoOrganization { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Nickname { get; set; }

        public WalletAddressEntity WalletAddresses { get; set; }
        public ICollection<WalletAddressEntity> WalletAddressesCollection { get; set; }
    }
}
