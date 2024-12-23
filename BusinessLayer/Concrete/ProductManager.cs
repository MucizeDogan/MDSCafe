using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.PoductDto;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class ProductManager : IProductService {

        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal) {
            _productDal = productDal;
        }

        public void TAdd(Product entity) {
            _productDal.Add(entity);
        }

        public int TCategoryCount() {
            return _productDal.CategoryCount();
        }

        public void TDelete(Product entity) {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id) {
          return  _productDal.GetById(id);
        }

        public List<Product> TGetListAll() {
            return _productDal.GetListAll();
        }

        public List<ResultProductWithCategory> TGetProductsWithCategories() {
            return _productDal.GetProductsWithCategories();
        }

        public decimal THamburgerAvg() {
            return _productDal.HamburgerAvg();
        }

        public string TLowestPricedProductName() {
            return _productDal.LowestPricedProductName();
        }

        public int TProductCountByCategoryNameDrink() {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger() {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public string TProductNameByPriceHighest() {
            return _productDal.ProductNameByPriceHighest();
        }

        public decimal TProductPriceAvg() {
            return _productDal.ProductPriceAvg();
        }

        public void TUpdate(Product entity) {
            _productDal.Update(entity);
        }
    }
}
