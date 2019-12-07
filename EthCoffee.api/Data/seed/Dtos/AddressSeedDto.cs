using System;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class AddressSeedDto
    {
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}