using System;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class UserAddressSeedDto
    {
        public AddressSeedDto Address { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}