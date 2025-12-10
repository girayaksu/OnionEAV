using AutoMapper;
using OnionEAV.Application.DTOClasses;
using OnionEAV.WebApi.RequestModels.Categories;
using OnionEAV.WebApi.ResponseModels.Categories;

namespace OnionEAV.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();
        }
    }
}
