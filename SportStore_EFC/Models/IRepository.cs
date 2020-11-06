using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        public void AddProduct(Product p);

        public void UpdateProduct(Product p);

        public Product GetProduct(long key);

        public void UpdateAll(Product[] products);

        public void Delete(Product p);
    }
}
