using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetListings()
        {
            var listings = await _repo.GetListings();
            var listingsToReturn = _mapper.Map<IEnumerable<ListingSearchResultsDto>>(listings);

            return Ok(listingsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetListing(int id)
        {
            var listing = await _repo.GetListing(id);
            
            var listingToReturn = _mapper.Map<ListingDetailsDto>(listing);

            return Ok(listingToReturn);
        }

    }
}