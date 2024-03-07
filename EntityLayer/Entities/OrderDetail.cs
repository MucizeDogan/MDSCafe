using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities {
    public class OrderDetail {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; } //Birim Fiyat
        public decimal TotalPrice { get; set; } //=Birim Fiyat * Count
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
