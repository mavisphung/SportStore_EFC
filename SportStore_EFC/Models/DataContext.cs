using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts)
        {
        }

        //để quản lí được mỗi table mình phải tạo 1 class với tên là: tên table + Repository

        //mỗi thằng DbSet sẽ là biến trỏ tới table để thao tác trên table đấy
        public DbSet<Product> Products { get; set; }

        
        public DbSet<Category> Categories { get; set; }


    }
}
