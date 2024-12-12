using EntityLayer.Entities;

namespace DataAccessLayer.Abstract {
    public interface IDiscountDal : IGenericDal<Discount> {
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
    }
}
