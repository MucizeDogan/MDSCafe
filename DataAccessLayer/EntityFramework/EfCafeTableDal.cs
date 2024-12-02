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
    }
}
