using System;
using System.Collections.Generic;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class ListingSeedDto
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<ListingPhotoSeedDto> Photos { get; set; }
    }
}