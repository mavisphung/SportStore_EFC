using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext context;

        public OrderRepository(DataContext context)
        {
            this.context = context;
        }
        public IEnumerable<Order> Orders => context.Orders
            .Include(order => order.Lines)
            .ThenInclude(line => line.Product);

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrder(long key) => context.Orders
            .Include(order => order.Lines).First(order => order.ID == key);

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }
    }
}
