using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper) {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNotificationList() {
            return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult GetNotificationCountByStatusFalse() {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByStatusFalse")]
        public IActionResult GetAllNotificationByStatusFalse() {
            return Ok(_notificationService.TGetAllNotificationByStatusFalse()); 
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto) {
            createNotificationDto.Status = false;
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var value = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(value);
            return Ok("Yeni bildirim ekleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id) {
            var value = _notificationService.TGetById(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim başarılı bir şekilde silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id) {
            var value = _notificationService.TGetById(id);
            return Ok(_mapper.Map<GetNotificationDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto) {
            var value = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(value);
            return Ok("Bildirim Güncelleme başarılı");
        }

        [HttpGet("NotificationChangeToFalse/{id}")]
        public IActionResult NotificationChangeToFalse(int id) {
            _notificationService.TNotificationChangeToFalse(id);
            return Ok("Bildirim durumu False olarak güncellendi");
        }

        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id) {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("Bildirim durumu True olarak güncellendi");
        }

        [HttpPost("DeleteAllNotificationByTrue")]
        public IActionResult DeleteAllNotificationByTrue() {
            _notificationService.TDeleteAllNotificationByTrue(); // Okunmuş olanları sil
            return Ok("Okunmuş tüm bildirimler başarıyla silindi");
        }
    }
}
