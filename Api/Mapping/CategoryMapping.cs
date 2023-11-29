using AutoMapper;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class CategoryMapping : Profile {
        public CategoryMapping() {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateBookingDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
        }
    }
}
