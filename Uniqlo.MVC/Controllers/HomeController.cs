using Microsoft.AspNetCore.Mvc;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.BL.Services.Concretes;
using Uniqlo.DAL.Models;

namespace Uniqlo.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderItemService _sliderItemService;

        public HomeController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }

        public IActionResult Index()
        {
            IEnumerable<SliderItem> sliderItems = _sliderItemService.GetAllSliderItems();
            return View(sliderItems);
        }


    }
}
