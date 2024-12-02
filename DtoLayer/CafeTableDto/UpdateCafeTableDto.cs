using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.CafeTableDto {
    public class UpdateCafeTableDto {
        public int CafeTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
