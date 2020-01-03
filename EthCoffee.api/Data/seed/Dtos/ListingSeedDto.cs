using System;
using System.Collections.Generic;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class ListingSeedDto
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<ListingPhotoSeedDto> Photos { get; set; }
    }
}