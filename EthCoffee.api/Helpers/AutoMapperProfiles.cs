using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EthCoffee.api.Dtos;
using EthCoffee.api.Models;

namespace EthCoffee.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Listing, ListingSearchResultsDto>()
            .ForMember(dest => dest.ListingPhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            });

            CreateMap<Listing, ListingDetailsDto>()
            .ForMember(dest => dest.ListingPhotoUrl, opt =>
            {
                opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            });

            CreateMap<User, UserListingsDto>()
            .ForMember(dest => dest.PhysicalAddress, opt =>
            {
                opt.MapFrom(src => src.UserAddresses.FirstOrDefault(addr => addr.AddressTypeId == 1).Address);
            });

            CreateMap<User, UserDetailsDto>()
                        .ForMember(dest => dest.PhysicalAddress, opt =>
            {
                opt.MapFrom(src => src.UserAddresses.FirstOrDefault(addr => addr.AddressTypeId == 1).Address);
            });

            CreateMap<ListingPhoto, ListingPhotosDetailedDto>();

            CreateMap<Avatar, AvatarsDetailedDto>();

            CreateMap<ListingDetailsUpdateDto, Listing>();

            CreateMap<UserDetailsUpdateDto, User>();

            CreateMap<PhotoForCreationDto, ListingPhoto>();
            CreateMap<PhotoForCreationDto, Avatar>();

            CreateMap<ListingPhoto, ListingPhotoForReturnDto>();
            CreateMap<Avatar, AvatarForReturnDto>();
            CreateMap<UserAddress, UserAddressDto>()
            .ForMember(dest => dest.AddressType, opt =>
            {
                opt.MapFrom(src => src.AddressType.Type);
            });
            CreateMap<UserRegisterDto, User>();

            CreateMap<MessageForCreationDto, Message>().ReverseMap();
        }
    }
}