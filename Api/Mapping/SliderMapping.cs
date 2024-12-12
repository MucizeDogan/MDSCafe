using AutoMapper;
using DtoLayer.SliderDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class SliderMapping : Profile {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            //CreateMap<Slider, CreateSliderDto>().ReverseMap();
            //CreateMap<Slider, GetSliderDto>().ReverseMap();
            //CreateMap<Slider, UpdateSliderDto>().ReverseMap();
        }
    }
}
