using System;
using System.Collections.Generic;

namespace EthCoffee.api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte [] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }        
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Bio { get; set; }
        public string Interests { get; set; }
               
        public Avatar Avatar { get; set; }
        public ICollection<Listing> MyListings { get; set; }
    }
}