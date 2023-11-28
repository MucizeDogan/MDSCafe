using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class ContactMeManager : IContactMeService {

        private readonly IContactMeDal _contactMeDal;

        public ContactMeManager(IContactMeDal contactMeDal) {
            _contactMeDal = contactMeDal;
        }

        public void TAdd(ContactMe entity) {
            _contactMeDal.Add(entity);
        }

        public void TDelete(ContactMe entity) {
            _contactMeDal.Delete(entity);
        }

        public ContactMe TGetById(int id) {
        return _contactMeDal.GetById(id);
        }

        public List<ContactMe> TGetListAll() {
        return _contactMeDal.GetListAll();
        }

        public void TUpdate(ContactMe entity) {
            _contactMeDal.Update(entity);
        }
    }
}
