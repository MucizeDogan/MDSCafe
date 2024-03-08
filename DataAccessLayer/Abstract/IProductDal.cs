using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract {
    public interface IProductDal : IGenericDal<Product> {
        List<Product> GetProductsWithCategories();

        public int CategoryCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        string LowestPricedProductName();
        string ProductNameByPriceHighest();
        decimal ProductPriceAvg();
        decimal HamburgerAvg();

    }
}
