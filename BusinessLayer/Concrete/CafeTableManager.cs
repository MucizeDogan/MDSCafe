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
            _cafeTableDal.Add(entity);
        }

        public int TCafeTableCount() {
            return _cafeTableDal.CafeTableCount();
        }

        public void TChangeStatusTableStatusToFalse(int id) {
            _cafeTableDal.ChangeStatusTableStatusToFalse(id);
        }

        public void TChangeStatusTableStatusToTrue(int id) {
            _cafeTableDal.ChangeStatusTableStatusToTrue(id);
        }

        public void TDelete(CafeTable entity) {
             _cafeTableDal.Delete(entity);
        }

        public CafeTable TGetById(int id) {
             return _cafeTableDal.GetById(id);
        }

        public List<CafeTable> TGetListAll() {
             return _cafeTableDal.GetListAll();
        }

        public void TUpdate(CafeTable entity) {
             _cafeTableDal.Update(entity);
        }
    }
}
