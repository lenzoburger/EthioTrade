using System;
using System.Collections.Generic;
using EthCoffee.api.Models;

namespace EthCoffee.api.Dtos
{
    public class UserListingsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Address PhysicalAddress { get; set; }
        public ICollection<UserAddressDto> UserAddresses { get; set; }                      
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public string AvatarUrl { get; set; }               
        public AvatarsDetailedDto Avatar { get; set; }
        public ICollection<ListingSearchResultsDto> MyListings { get; set; }
    }
}