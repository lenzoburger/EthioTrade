using System;
using System.Collections.Generic;
using EthCoffee.api.Models;

namespace EthCoffee.api.Dtos
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }    
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Bio { get; set; }

        public string AvatarUrl { get; set; }               
        public AvatarsDetailedDto Avatar { get; set; }
        public ICollection<ListingSearchResultsDto> MyListings { get; set; }
    }
}