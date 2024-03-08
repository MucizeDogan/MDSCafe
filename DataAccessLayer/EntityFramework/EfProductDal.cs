﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework {
    public class EfProductDal : GenericRepository<Product>, IProductDal {
        public EfProductDal(Context context) : base(context) {
        }

        public int CategoryCount() {
            using var context = new Context();
            return context.Products.Count();
        }

        public List<Product> GetProductsWithCategories() {
            var context = new Context();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public string LowestPricedProductName() {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public int ProductCountByCategoryNameDrink() {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
            // SQL cümlesi = Select * from Products Where CategoryID = (Select categoryID from Categories where CategoryName = 'İçecek')
        }

        public int ProductCountByCategoryNameHamburger() {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
            //SQL cümlesi = Select * from Products Where CategoryID = (Select categoryID from Categories where CategoryName = 'Hamburger')
        }

        public string ProductNameByPriceHighest() {
            using var context = new Context();
            return context.Products.Where(x => x.Price == (context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg() {
            using var context = new Context();
            return context.Products.Average(x => x.Price);
        }
        public decimal HamburgerAvg() {
            using var context = new Context();
            return context.Products.Where(x => x.CategoryID == 2).Average(y => y.Price);
        }
    }
}
