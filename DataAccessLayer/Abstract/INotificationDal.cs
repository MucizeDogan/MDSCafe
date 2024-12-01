using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract {
    public interface INotificationDal : IGenericDal<Notification> {
        int NotificationCountByStatusFalse();
        List<Notification> GetAllNotificationByStatusFalse(); // Durumu okunmamış olanları listele
        void NotificationChangeToTrue(int id); // Okundu olarak işaretle
        void NotificationChangeToFalse(int id);
        void DeleteAllNotificationByTrue();
    }
}
