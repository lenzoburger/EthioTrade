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
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }    
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }               
        public Avatar Avatar { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public ICollection<Listing> MyListings { get; set; }
        public ICollection<ListingWatch> Watchings { get; set; }
        public ICollection<Message> MessageSent { get; set; }
        public ICollection<Message> MessageReceived { get; set; }
    }
}