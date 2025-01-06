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
    public class EfCafeTableDal : GenericRepository<CafeTable>, ICafeTableDal {
        public EfCafeTableDal(Context context) : base(context) {
        }
        public int CafeTableCount() {
            using var context = new Context();
            return context.CafeTables.Count();
        }

        public void ChangeStatusTableStatusToFalse(int id) {
            using var context = new Context();
            var value = context.CafeTables.Where(x => x.CafeTableID == id).FirstOrDefault();
            if (value != null) {
                value.Status = false; // Masa boş duruma geçiyor.
                context.SaveChanges();
            }
        }

        public void ChangeStatusTableStatusToTrue(int id) {
            using var context = new Context();
            var value = context.CafeTables.Where(x => x.CafeTableID == id).FirstOrDefault();
            if (value != null) {
                value.Status = true; // Masa dolu duruma geçiyor.
                context.SaveChanges();
            }
        }
    }
}
