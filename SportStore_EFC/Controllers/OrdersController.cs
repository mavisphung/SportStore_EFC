using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore_EFC.Models;

namespace SportStore_EFC.Controllers
{
    public class OrdersController : Controller
    {
        private IRepository productRepository;
        private IOrderRepository ordersRepository;

        public OrdersController(IRepository productRepository, IOrderRepository ordersRepository)
        {
            this.productRepository = productRepository;
            this.ordersRepository = ordersRepository;
        }
        public IActionResult Index()
        {
            //controller của thằng nào thì trả về kiểu repository của thằng đó
            return View(ordersRepository.Orders);
        }

        public IActionResult EditOrder(long id)
        {
            var products = productRepository.Products;
            Order order = id == 0 ? new Order() : ordersRepository.GetOrder(id);
            IDictionary<long, OrderLine> linesMap
            = order.Lines?.ToDictionary(l => l.ProductID)
            ?? new Dictionary<long, OrderLine>();
            ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.ID)
            ? linesMap[p.ID] : new OrderLine { Product = p, ProductID = p.ID, Quantity = 0 });
            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrUpdateOrder(Order order)
        {
            order.Lines = order.Lines
                   .Where(l => l.ID > 0 || (l.ID == 0 && l.Quantity > 0)).ToArray();
            if (order.ID == 0)
            {
                ordersRepository.AddOrder(order);
            }
            else
            {
                ordersRepository.UpdateOrder(order);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteOrder(Order order)
        {
            ordersRepository.DeleteOrder(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
