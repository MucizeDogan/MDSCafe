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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal {
        public EfBookingDal(Context context) : base(context) {
        }

        public void BookingStatusApproved(int id) {
            using var context = new Context();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusCancelled(int id) {
            using var context = new Context();
            var values = context.Bookings.Find(id);
            values.Description = "Rezervasyon İptal Edildi";
            context.SaveChanges();
        }
    }
}
