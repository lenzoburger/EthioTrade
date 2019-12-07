using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EthCoffee.api.Models
{
    public class Listing
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(19,4)")]
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<ListingPhoto> Photos { get; set; }
        public ICollection<ListingWatch> Watchers { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}