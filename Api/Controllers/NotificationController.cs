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

        public NotificationController(INotificationService notificationService) {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult GetNotificationList() {
            return Ok(_notificationService.TGetListAll());
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
            Notification notification = new Notification() {
                Description = createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Status = false,
                NotificationType = createNotificationDto.NotificationType,
                NotificationTypeText = createNotificationDto.NotificationTypeText,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())

            };
            _notificationService.TAdd(notification);
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
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto) {
            Notification notification = new Notification() {
                NotificationID = updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Status = updateNotificationDto.Status,
                NotificationType = updateNotificationDto.NotificationType,
                NotificationTypeText = updateNotificationDto.NotificationTypeText,
                Date = Convert.ToDateTime(updateNotificationDto.Date.ToShortDateString())

            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim Güncelleme başarılı");
        }
    }
}
