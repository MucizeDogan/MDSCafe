using AutoMapper;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class SocialMediaMapping :Profile {
        public SocialMediaMapping() {
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        }
    }
}
