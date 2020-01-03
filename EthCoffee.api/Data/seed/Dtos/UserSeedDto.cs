using System;
using System.Collections.Generic;

namespace EthCoffee.api.Data.seed.Dtos
{
    public class UserSeedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; } = "Password";
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }    
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }               
        public AvatarSeedDto Avatar { get; set; }
        public ICollection<UserAddressSeedDto> UserAddresses { get; set; }
        public ICollection<ListingSeedDto> MyListings { get; set; }
    }
}