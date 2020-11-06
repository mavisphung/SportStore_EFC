using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore_EFC.Models;

namespace SportStore_EFC.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        private ICategoryRepository cateRepository;

        public HomeController(IRepository repo, ICategoryRepository cateRepo)
        {
            repository = repo;
            cateRepository = cateRepo;
        }
        public IActionResult Index()
        {
            //System.Console.Clear();
            ViewBag.Categories = cateRepository.Categories;
            return View(repository.Products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            repository.AddProduct(p);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProduct(long key)
        {
            //return View(repository.GetProduct(key));
            ViewBag.Categories = cateRepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            //kiểm tra xem có id chưa
            //khi chưa có id, .NET tự gán cho biến kiểu số = 0
            if (p.ID == 0)
            {
                repository.AddProduct(p);
            } else
            {
                repository.UpdateProduct(p);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            return View(nameof(Index), repository.Products);
        }

        [HttpPost]
        public IActionResult UpdateAll(Product[] products)
        {
            repository.UpdateAll(products);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
