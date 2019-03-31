using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EthCoffee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController (IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {  
            var userFromRepo = await _repo.Login(userLoginDto.Username.ToLower(),userLoginDto.Password);

            if (userFromRepo == null) 
            {
                return Unauthorized();
            }
            
            var tokenDescriptor = CreateTokenDescriptor(userFromRepo);

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok( new {
                token = tokenHandler.WriteToken(token)
            });
        }

        private SecurityTokenDescriptor CreateTokenDescriptor(User userFromRepo)
        {
            //Set claim/tokenSubject with username and ID
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            //Get and convert secret Key from AppSettings
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));
            
            //Hash Secret Jey
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Combine tokenSubject + expiryDate + Hashed secretKey
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            return tokenDescriptor;            
        }
    }
}