using System;

namespace EthCoffee.api.Helpers
{
    public class FilterParams
    {
        public string Category { get; set; } = "";      
        public string Title { get; set; } = "";
        public DateTime DateAdded { get; set; }
    }
}