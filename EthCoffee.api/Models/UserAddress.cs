using System;

namespace EthCoffee.api.Models
{
    public class UserAddress
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public AddressType AddressType { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}