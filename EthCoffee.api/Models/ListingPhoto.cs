using System;

namespace EthCoffee.api.Models
{
    public class ListingPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId  { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public Listing Listing { get; set; }
        public int ListingId { get; set; }
    }
}