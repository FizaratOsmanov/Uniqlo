using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.BL.Services.Concretes;
using Uniqlo.DAL;
using Uniqlo.DAL.Models;
namespace Uniqlo.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> Products = _productService.GetAllProducts();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {

            _productService.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _productService.UpdateProduct(id, product);

            return RedirectToAction(nameof(Index));
        }

    }
}
