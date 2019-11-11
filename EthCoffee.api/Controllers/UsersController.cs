using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Helpers;
using EthCoffee.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EthCoffee.api.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
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

        [HttpGet("{id}", Name = "GetUserDetails")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _repo.GetUserDetails(id);

            var userToReturn = _mapper.Map<User, UserDetailsDto>(user);

            return Ok(userToReturn);
        }

        [HttpGet("{id}/listings")]
        public async Task<IActionResult> GetUserListings(int id)
        {
            var userListings = await _repo.GetUserListings(id);

            var listingsToReturn = _mapper.Map<IEnumerable<ListingSearchResultsDto>>(userListings);

            return Ok(listingsToReturn);
        }

        [HttpPost("{id}/watch/{listingId}")]
        public async Task<IActionResult> WatchListing(int id, int listingId)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            if (await _repo.GetListing(listingId) == null)
                return NotFound();

            var listingWatch = await _repo.GetListingWatch(id, listingId);

            string action;

            if (listingWatch != null)
            {
                action = "Unwatch";
                _repo.Delete<ListingWatch>(listingWatch);
            }
            else
            {
                listingWatch = new ListingWatch
                {
                    WatcherId = id,
                    WatchingId = listingId
                };

                action = "Watch";
                _repo.Add<ListingWatch>(listingWatch);
            }

            var message = $"{action} listing successful. [WatcherId={listingWatch.WatcherId}, WatchingID={listingWatch.WatchingId}]";

            if (await _repo.SaveAll())
                return Ok(new { action, message });


            return BadRequest($"Failed to {action} listing");
        }

        [HttpGet("{id}/watching")]
        public async Task<IActionResult> GetWatching(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var watchList = await _repo.GetWatching(id);

            var watchListToReturn = _mapper.Map<IEnumerable<ListingSearchResultsDto>>(watchList);

            return Ok(watchListToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDetailsUpdateDto userUpdate)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var userFromRepo = await _repo.GetUserDetails(id);

            _mapper.Map(userUpdate, userFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating user details failed on save");
        }

    }
}