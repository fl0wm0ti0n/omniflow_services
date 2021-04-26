using System;
using System.Collections.Generic;

namespace DataTransferObjects.NodeMon
{
    public class FarmerDto
    {
        public int Id { get; set; }
        public long ThreebotId { get; set; }
        public string IyoOrganization { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public WalletAddressDto WalletAddresses { get; set; }
        public ICollection<WalletAddressDto> WalletAddressesCollection { get; set; }
    }
}
