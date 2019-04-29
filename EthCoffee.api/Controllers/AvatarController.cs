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
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    [Authorize]
    public class AvatarController : ControllerBase
    {
        private readonly ITradingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public AvatarController(ITradingRepository repo, IMapper mapper,
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

        [HttpGet("{id}", Name = "GetAvatar")]
        public async Task<IActionResult> GetAvatar(int id)
        {
            var avatarFromRepo = await _repo.GetAvatar(id);
            var avatar = _mapper.Map<AvatarForReturnDto>(avatarFromRepo);

            return Ok(avatar);
        }

        [HttpPost]
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
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<Avatar>(photoForCreationDto);


            if (userFromRepo.Avatar != null)
            {
                var avatarFromRepo = await _repo.GetAvatar(userFromRepo.Avatar.Id);

                if (avatarFromRepo.PublicId != null)
                {
                    var deleteParams = new DeletionParams(avatarFromRepo.PublicId);

                    var result = _cloudinary.Destroy(deleteParams);

                    if (result.Result == "ok")
                    {
                        _repo.Delete(avatarFromRepo);
                    }
                }
                else if (avatarFromRepo.PublicId == null)
                {
                    _repo.Delete(avatarFromRepo);
                }
            }

            userFromRepo.Avatar = photo;

            if (await _repo.SaveAll())
            {
                var photoToReturn = _mapper.Map<AvatarForReturnDto>(photo);
                return CreatedAtRoute("GetAvatar", new { id = photo.Id }, photoToReturn);
            }

            return BadRequest("Could not save the avatar photo");
        }

    }
}