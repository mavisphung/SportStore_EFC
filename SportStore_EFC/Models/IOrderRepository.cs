using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        Order GetOrder(long key);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
