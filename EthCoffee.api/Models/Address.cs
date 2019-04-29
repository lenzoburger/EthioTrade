using System;

namespace EthCoffee.api.Models
{
    public class Address
    {
        public int id { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}