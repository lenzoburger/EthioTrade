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
    [Route("api")]
    [ApiController]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly ITradingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(ITradingRepository repo, IMapper mapper,
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

        [HttpGet("{id}", Name = "GetAvatar")]
        public async Task<IActionResult> GetAvatar(int id)
        {
            var avatarFromRepo = await _repo.GetAvatar(id);
            var avatar = _mapper.Map<AvatarForReturnDto>(avatarFromRepo);

            return Ok(avatar);
        }

        [HttpPost("listings/{listingId}/[controller]")]
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
                return CreatedAtRoute("GetListingPhoto", new {id = photo.Id}, photoToReturn);
            }

            return BadRequest("Could not save the listing photo");
        }

        [HttpPost("users/{userId}/[controller]")]
        public async Task<IActionResult> AddPhotoForUser(int userId, [FromForm]PhotoForCreationDto photoForCreationDto)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var userFromRepo = await _repo.GetUserDetails(userId);

            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation()
                        .Width(250).Height(250).Crop("fit").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Avatar>(photoForCreationDto);

            userFromRepo.Avatar = photo;

            if (await _repo.SaveAll())
            {
                var photoToReturn = _mapper.Map<AvatarForReturnDto>(photo);
                return CreatedAtRoute("GetAvatar", new {id = photo.Id}, photoToReturn);
            }

            return BadRequest("Could not save the avatar photo");
        }
    }
}