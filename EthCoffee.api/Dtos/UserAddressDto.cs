using EthCoffee.api.Models;

namespace EthCoffee.api.Dtos
{
    public class UserAddressDto
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public string AddressType { get; set; }
        public Address Address { get; set; }
    }
}