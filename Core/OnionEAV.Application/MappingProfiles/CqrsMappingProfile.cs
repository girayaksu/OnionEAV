using AutoMapper;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Application.MappingProfiles
{
    public class CqrsMappingProfile : Profile
    {
        public CqrsMappingProfile()
        {


            CreateMap<Category, GetCategoryQueryResult>();
            CreateMap<Category, GetCategoryByIdQueryResult>();

            CreateMap<CreateCategoryCommand, Category>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Domain.Enums.DataStatus.Inserted));

            CreateMap<UpdateCategoryCommand, Category>()
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Domain.Enums.DataStatus.Updated));
        }
    }
}


