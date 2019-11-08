using System;
using System.Collections.Generic;
using EthCoffee.api.Models;

namespace EthCoffee.api.Dtos
{
    public class ListingDetailsDto
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime DateAdded { get; set; }
        public string ListingPhotoUrl { get; set; }
        public ICollection<ListingPhotosDetailedDto> Photos { get; set; }
        public UserDetailsDto User { get; set; }
    }
}