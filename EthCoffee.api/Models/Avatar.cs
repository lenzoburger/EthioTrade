using System;

namespace EthCoffee.api.Models
{
    public class Avatar
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }
    }
}