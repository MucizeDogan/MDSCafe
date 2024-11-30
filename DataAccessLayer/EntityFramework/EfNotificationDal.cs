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

        public int NotificationCountByStatusFalse() {
            using var context = new Context();
            return context.Notifications.Where(x=>x.Status==false).Count();
        }
    }
}
