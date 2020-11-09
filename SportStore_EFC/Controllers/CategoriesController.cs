using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore_EFC.Models;

namespace SportStore_EFC.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository repository;

        public CategoriesController(ICategoryRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Categories);
        }

        public IActionResult AddCategory(Category cate)
        {
            repository.AddCategory(cate);
            //sau khi add vào thì trở lại CategoryController/Index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategory(long id)
        {
            ViewBag.EditID = id;
            return View("Index", repository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category cate)
        {
            repository.UpdateCategory(cate);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteCategory(Category cate)
        {
            repository.DeleteCategory(cate);
            return RedirectToAction(nameof(Index));
        }
    }
}
