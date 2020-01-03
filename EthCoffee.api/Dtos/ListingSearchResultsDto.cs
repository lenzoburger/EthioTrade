using System;

namespace EthCoffee.api.Dtos
{
    public class ListingSearchResultsDto
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool watching { get; set; } = false;
        public DateTime DateAdded { get; set; }
        public string ListingPhotoUrl { get; set; }
    }
}