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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal {
        public EfOrderDal(Context context) : base(context) {
        }

        public int ActiveOrderCount() { // Aktif Sipariş Sayısı
            using var context = new Context();
            return context.Orders.Where(x=>x.Description== "Müşteri Masada").Count();
        }

        public decimal LastOrderTotalPrice() { // Son Sipariş Tutarı
            using var context = new Context();
            return context.Orders.OrderByDescending(x=>x.OrderID).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public int TotalOrderCount() { // Toplam Sipariş Sayısı
            using var context = new Context();
            return context.Orders.Count();
        }
    }
}
