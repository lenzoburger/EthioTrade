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
    }
}