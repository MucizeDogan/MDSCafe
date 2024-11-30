using BusinessLayer.Abstract;
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
    }
}
