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

        public int CategoryCount() {
            using var context = new Context();
            return context.Categories.Count();
        }
    }
}
