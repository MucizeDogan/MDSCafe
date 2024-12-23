using DtoLayer.PoductDto;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface IProductService : IGenericService<Product> {
        List<ResultProductWithCategory> TGetProductsWithCategories();
        public int TCategoryCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        string TLowestPricedProductName();
        string TProductNameByPriceHighest();
        decimal THamburgerAvg();
    }
}
