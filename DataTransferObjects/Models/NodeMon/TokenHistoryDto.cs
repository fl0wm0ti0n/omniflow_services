using System;
using System.Collections.Generic;

namespace DataTransferObjects.Models.NodeMon
{
    public class TokenHistoryDto
    {
        public int TokenHistoryEntityId { get; set; }
        public long AmountOfTokens { get; set; }
        public ICollection<WalletAddressDto> WalletAddress { get; set; }
        public DateTime PayOutDate { get; set; }
        public int NodeEntityId { get; set; }
    }
}