using AutoMapper;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class DiscountMapping :Profile {
        public DiscountMapping() {
            CreateMap<Discount,ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
        }
    }
}
