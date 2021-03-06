using API.DTOs;
using AutoMapper;

namespace API.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();

            CreateMap<ItemImage, PhotoDto>();

            CreateMap<AddItemListingDto, ItemListing>();

            CreateMap<ItemListing, ItemListingDto>();

            CreateMap<ItemCategory, ItemCategoryDto>();
        }
    }
}
