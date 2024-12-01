using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Dtos.NotificationDto {
    public class CreateNotificationDto {
        public int NotificationType { get; set; }
        public string NotificationTypeText { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
