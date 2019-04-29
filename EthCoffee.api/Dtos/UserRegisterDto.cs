using System;
using System.ComponentModel.DataAnnotations;

namespace EthCoffee.api.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20,MinimumLength =8, ErrorMessage = "You must specify a password between 8 and 20 characters.")]
        public string Password { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Firstname { get; set; }
        
        [Required]
        public string Lastname { get; set; }
       
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public string Phone { get; set; }    
        
        public DateTime LastActiveDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserRegisterDto()
        {
            CreatedDate = DateTime.Now;
            LastActiveDate = DateTime.Now;
        }   
    }
}