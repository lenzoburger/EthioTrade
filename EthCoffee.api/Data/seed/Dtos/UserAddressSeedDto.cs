using System;
using EthCoffee.api.Models;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class UserAddressSeedDto
    {
        public int UserId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}