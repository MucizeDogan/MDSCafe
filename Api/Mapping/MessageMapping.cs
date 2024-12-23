using AutoMapper;
using DtoLayer.MessageDto;
using EntityLayer.Entities;

namespace Api.Mapping {
    public class MessageMapping : Profile {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
        }
    }
}
