using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class CafeTableManager : ICafeTableService {
        private readonly ICafeTableDal _cafeTableDal;

        public CafeTableManager(ICafeTableDal cafeTableDal) {
            _cafeTableDal = cafeTableDal;
        }

        public void TAdd(CafeTable entity) {
            throw new NotImplementedException();
        }

        public int TCafeTableCount() {
            return _cafeTableDal.CafeTableCount();
        }

        public void TDelete(CafeTable entity) {
            throw new NotImplementedException();
        }

        public CafeTable TGetById(int id) {
            throw new NotImplementedException();
        }

        public List<CafeTable> TGetListAll() {
            throw new NotImplementedException();
        }

        public void TUpdate(CafeTable entity) {
            throw new NotImplementedException();
        }
    }
}
