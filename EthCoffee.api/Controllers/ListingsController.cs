using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace EthCoffee.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingsController : ControllerBase
    {
        private readonly ITradingRepository _repo;
        private readonly IMapper _mapper;
        public ListingsController(ITradingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetListings([FromQuery]PaginationParams paginationParams, [FromQuery]FilterParams filterParams)
        {
            var userId = User != null ? int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value) : -1;

            var listings = await _repo.GetListings(paginationParams, filterParams, userId);

            var listingsToReturn = _mapper.Map<IEnumerable<ListingSearchResultsDto>>(listings);

            Response.AddPagination(listings.PageNumber, listings.PageSize, listings.TotalPages, listings.TotalItems);

            return Ok(listingsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListing(int id)
        {
            var listing = await _repo.GetListing(id);

            var listingToReturn = _mapper.Map<ListingDetailsDto>(listing);

            return Ok(listingToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateListing(int id, ListingDetailsUpdateDto listingUpdate)
        {
            var listingFromRepo = await _repo.GetListing(id);

            if (listingFromRepo.UserId != int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value))
            {
                return Unauthorized();
            }

            _mapper.Map(listingUpdate, listingFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating listing {id} failed on save");
        }
    }
}