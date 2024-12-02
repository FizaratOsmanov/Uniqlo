using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL.Models;
using System.Collections.Generic;
using Uniqlo.BL.Services.Concretes;
namespace Uniqlo.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        public IActionResult Index()
        {

            IEnumerable<Category>? Categories = _categoryService.GetAllCategories();
            return View(Categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category); // Return with validation errors
            }
            Category category2 = new Category
            {
                CategoryName = category.CategoryName,
                CreateDate = DateTime.Now,
                

            };

           _categoryService.CreateCategory(category2);

           
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            Category category =_categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _categoryService.UpdateCategory(id, category);

            return RedirectToAction(nameof(Index));
        }
    }
}
