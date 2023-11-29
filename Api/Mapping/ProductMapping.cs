using AutoMapper;
using DtoLayer.PoductDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class ProductMapping : Profile {
        public ProductMapping() {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
