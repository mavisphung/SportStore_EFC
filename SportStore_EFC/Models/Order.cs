using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class Order
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool Shipped { get; set; }
        public IEnumerable<OrderLine> Lines { get; set; }
    }
}
