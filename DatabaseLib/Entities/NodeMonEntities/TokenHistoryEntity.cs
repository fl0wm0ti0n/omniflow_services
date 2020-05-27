using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DatabaseLib.Entities
{
    [Table("nodemon_TokenHistory")]
    public class TokenHistoryEntity
    {
        [Key]
        [Required]
        public int TokenHistoryEntityId { get; set; }
        [Required]
        public long AmountOfTokens { get; set; }
        [Required]
        public ICollection<WalletAddressEntity> WalletAddress { get; set; }
        [Required]
        public DateTime PayOutDate { get; set; }
        [Required]
        public int NodeEntityId { get; set; }
        [Required]
        public NodeEntity NodeEntity { get; set; }
    }
}
