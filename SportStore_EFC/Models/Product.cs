using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }

        //public string Category { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal RetailPrice { get; set; }


        //cái này được xem như là foreign key
        //Đặt tên theo class name + thuộc tính khóa chính của class
        public long CategoryID { get; set; }

        //Thường sẽ đi theo cặp, cứ có ID -> có luôn object chứa id đó
        public Category Category { get; set; }
    }
}
