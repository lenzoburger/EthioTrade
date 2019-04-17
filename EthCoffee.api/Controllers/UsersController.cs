using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EthCoffee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ITradingRepository _repo;
        private readonly IMapper _mapper;
        public UsersController(ITradingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _repo.GetUserDetails(id);

            var userToReturn = _mapper.Map<User, UserDetailsDto>(user);

            return Ok(userToReturn);
        }

        [HttpGet("listings/{id}")]
        public async Task<IActionResult> GetUserListings(int id)
        {
            var user = await _repo.GetUserListings(id);

            var userToReturn = _mapper.Map<User, UserListingsDto>(user);

            return Ok(userToReturn);
        }

    }
}