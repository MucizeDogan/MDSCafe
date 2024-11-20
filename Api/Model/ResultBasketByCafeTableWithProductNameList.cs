using EntityLayer.Entities;

namespace Api.Model {
    public class ResultBasketByCafeTableWithProductNameList {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int CafeTableID { get; set; }
        public string ProductName { get; set; }

    }
}
