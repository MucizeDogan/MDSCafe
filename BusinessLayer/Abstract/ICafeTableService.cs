using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract {
    public interface ICafeTableService : IGenericService<CafeTable> {
        int TCafeTableCount();
        void TChangeStatusTableStatusToTrue(int id); // True ise dolu
        void TChangeStatusTableStatusToFalse(int id);
    }
}
