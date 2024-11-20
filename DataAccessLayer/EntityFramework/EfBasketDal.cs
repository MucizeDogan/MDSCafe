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
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal {
        public EfBasketDal(Context context) : base(context) {
        }
        public List<Basket> GetBasketByCafeTableNumber(int cafeTableNumber) {
            using var context = new Context(); // Burada bir örnek aldık.
            var values = context.Baskets.Where(x => x.CafeTableID == cafeTableNumber).ToList(); // CafeTableID'si bizim dışardan gönderdiğimiz id ye eşitse listle 
            return values;
        }
    }
}
