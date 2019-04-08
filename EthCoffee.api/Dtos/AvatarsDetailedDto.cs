using System;

namespace EthCoffee.api.Dtos
{
    public class AvatarsDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
    }
}