using System;
using System.Collections.Generic;
using EthCoffee.api.Models;

namespace EthCoffee.api.Dtos
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }        
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
        public string AvatarUrl { get; set; }               
        public AvatarsDetailedDto Avatar { get; set; }
    }
}