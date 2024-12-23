using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.NotificationDto {
    public class GetNotificationDto {
        public int NotificationID { get; set; }
        public int NotificationType { get; set; }
        public string NotificationTypeText { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
