using System;

namespace EthCoffee.api.Helpers
{
    public class FilterParams
    {
        public string Category { get; set; } = "";      
        public string Title { get; set; } = "";
        public bool WatchlistOnly { get; set; } = false;
        public bool MyListingsOnly { get; set; } = false;
        public DateTime DateAdded { get; set; }
    }
}