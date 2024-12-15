using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities {
    public class Message {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }


    }
}
