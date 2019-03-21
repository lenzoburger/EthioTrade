using System.Threading.Tasks;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace EthCoffee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController (IAuthRepository repo)
        {
            _repo = repo;
        }

         [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto UserRegDto)
        {
            UserRegDto.Username = UserRegDto.Username.ToLower();

            if (await _repo.UserExists(UserRegDto.Username)){
                return BadRequest("Username already exists");
            }

            var userToCreate = new User{ Username = UserRegDto.Username };

            var createdUser = await _repo.Register(userToCreate,UserRegDto.Password);

            return StatusCode(201);
        }
    }
}