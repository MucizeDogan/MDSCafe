using AutoMapper;
using DtoLayer.ContactMeDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class ContactMeMapping : Profile{
        public ContactMeMapping() {
            CreateMap<ContactMe, ResultContactMeDto>().ReverseMap();
            CreateMap<ContactMe, CreateContactMeDto>().ReverseMap();
            CreateMap<ContactMe, UpdateContactMeDto>().ReverseMap();
            CreateMap<ContactMe, GetContactMeDto>().ReverseMap();
        }
    }
}
