using AutoMapper;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
namespace Api.Mapping {
    public class NotificationMapping : Profile{
        public NotificationMapping()
        {
            CreateMap<ResultNotificationDto, Notification>().ReverseMap();
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
        }
    }
}
