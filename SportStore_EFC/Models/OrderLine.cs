using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class OrderLine
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public long OrderID { get; set; }
        public Order Order { get; set; }
    }
}
