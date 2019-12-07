using System;

namespace EthCoffee.api.Models
{
    public class UserAddress
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}