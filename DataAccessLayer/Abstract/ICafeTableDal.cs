using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract {
    public interface ICafeTableDal : IGenericDal<CafeTable> {
        int CafeTableCount();
        void ChangeStatusTableStatusToTrue(int id); // True ise dolu
        void ChangeStatusTableStatusToFalse(int id);
    }
}
