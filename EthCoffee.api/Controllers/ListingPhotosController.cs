using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EthCoffee.api.Data;
using EthCoffee.api.Dtos;
using EthCoffee.api.Helpers;
using EthCoffee.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EthCoffee.api.Controllers
{
    [Route("api/listings/{listingId}/photos")]
    [ApiController]
    [Authorize]
    public class ListingPhotosController : ControllerBase
    {
        private readonly ITradingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public ListingPhotosController(ITradingRepository repo, IMapper mapper,
         IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("{id}", Name = "GetListingPhoto")]
        public async Task<IActionResult> GetListingPhoto(int id)
        {
            var listingPhotoFromRepo = await _repo.GetListingPhoto(id);
            var listingPhoto = _mapper.Map<ListingPhotoForReturnDto>(listingPhotoFromRepo);

            return Ok(listingPhoto);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForListing(int listingId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            var listingFromRepo = await _repo.GetListing(listingId);

            if (listingFromRepo.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<ListingPhoto>(photoForCreationDto);

            if (!listingFromRepo.Photos.Any(l => l.IsMain))
            {
                photo.IsMain = true;
            }

            listingFromRepo.Photos.Add(photo);

            if (await _repo.SaveAll())
            {
                var photoToReturn = _mapper.Map<ListingPhotoForReturnDto>(photo);
                return CreatedAtRoute("GetListingPhoto", new { id = photo.Id }, photoToReturn);
            }

            return BadRequest("Could not save the listing photo");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainListingPhoto(int listingId, int id)
        {
            var listingFromRepo = await _repo.GetListing(listingId);

            if (listingFromRepo.UserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            if (!listingFromRepo.Photos.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            var photoFromRepo = await _repo.GetListingPhoto(id);

            if (photoFromRepo.IsMain)
            {
                return BadRequest("This is already the main photo");
            }

            var currentMainPhoto = await _repo.GetMainListingPhoto(listingId);

            currentMainPhoto.IsMain = false;

            photoFromRepo.IsMain = true;

            if (await _repo.SaveAll())
            {
                return NoContent();
            }

            return BadRequest("Could not set photo to main");
        }
    }
}