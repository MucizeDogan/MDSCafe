using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities {
    public class CafeTable {
        public int CafeTableID{ get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
