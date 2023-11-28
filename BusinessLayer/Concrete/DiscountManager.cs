using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class DiscountManager : IDiscountService {

        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal) {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity) {
            throw new NotImplementedException();
        }

        public void TDelete(Discount entity) {
            throw new NotImplementedException();
        }

        public Discount TGetById(int id) {
            throw new NotImplementedException();
        }

        public List<Discount> TGetListAll() {
            throw new NotImplementedException();
        }

        public void TUpdate(Discount entity) {
            throw new NotImplementedException();
        }
    }
}
