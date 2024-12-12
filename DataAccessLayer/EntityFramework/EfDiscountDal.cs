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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal {
        public EfDiscountDal(Context context) : base(context) {
        }

        public void ChangeStatusToFalse(int id) {
            using var context = new Context();
            var value = context.Discounts.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id) {
            using var context = new Context();
            var value = context.Discounts.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
