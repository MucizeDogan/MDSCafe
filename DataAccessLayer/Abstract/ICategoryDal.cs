using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract {
    public interface ICategoryDal : IGenericDal<Category>{

        public int CategoryCount();
        public int ActiveCategoryCount(); // Aktif Kategori Sayısı
        public int PassiveCategoryCount(); // Pasif Kategori Sayısı
    }
}
