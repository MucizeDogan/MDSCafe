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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal {
        public EfCategoryDal(Context context) : base(context) {
        }

        public int ActiveCategoryCount() {
            using var context = new Context();
            int count = context.Categories.Where(x => x.Status==true).Count(); //Status ü true olanların sayısı
            return count;
        }

        public int CategoryCount() {
            using var context = new Context();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount() {
            using var context = new Context();
            return context.Categories.Where(x => x.Status == false).Count();
        }
    }
}
