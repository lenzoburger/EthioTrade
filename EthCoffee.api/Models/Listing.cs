using System;
using System.Collections.Generic;

namespace EthCoffee.api.Models
{
    public class Listing
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<ListingPhoto> Photos { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}