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
            
            CreateMap<User, UserListingsDto>();

            CreateMap<User, UserDetailsDto>();

            CreateMap<ListingPhoto, ListingPhotosDetailedDto>();

            CreateMap<Avatar, AvatarsDetailedDto>();
            
            CreateMap<ListingDetailsUpdateDto, Listing>();
        }
    }
}