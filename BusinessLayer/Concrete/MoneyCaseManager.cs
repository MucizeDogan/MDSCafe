using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class MoneyCaseManager : IMoneyCaseService {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal) {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity) {
            throw new NotImplementedException();
        }

        public void TDelete(MoneyCase entity) {
            throw new NotImplementedException();
        }

        public MoneyCase TGetById(int id) {
            throw new NotImplementedException();
        }

        public List<MoneyCase> TGetListAll() {
            throw new NotImplementedException();
        }

        public decimal TTotalMoneyCase() {
            return _moneyCaseDal.TotalMoneyCase();
        }

        public void TUpdate(MoneyCase entity) {
            throw new NotImplementedException();
        }
    }
}
