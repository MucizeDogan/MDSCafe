using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework {
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal {
        public EfNotificationDal(Context context) : base(context) {
        
        }

        public List<Notification> GetAllNotificationByStatusFalse() {
            using var context = new Context();
            return context.Notifications.Where(x => x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse() {
            using var context = new Context();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }

        public void NotificationChangeToTrue(int id) {
            using var context = new Context();
            var value = context.Notifications.Find(id);
            if (value != null) {
                value.Status = true;
                context.SaveChanges();
            }
        }

        public void NotificationChangeToFalse(int id) {
            using var context = new Context();
            var value = context.Notifications.Find(id);
            if (value != null) {
                value.Status = false;
                context.SaveChanges();
            }
        }

        public void DeleteAllNotificationByTrue() {
            using var context = new Context();
            var values = context.Notifications.Where(x => x.Status == true).ToList();
            // Tüm okunmuş bildirimleri sil
            context.Notifications.RemoveRange(values);

            // Değişiklikleri kaydet
            context.SaveChanges();

        }
    }
}
