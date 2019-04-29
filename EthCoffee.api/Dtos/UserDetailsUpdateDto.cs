using System;

namespace EthCoffee.api.Dtos
{
    public class UserDetailsUpdateDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }                 
    }
}