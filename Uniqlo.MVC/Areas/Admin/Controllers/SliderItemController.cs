using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.BL.Services.Concretes;
using Uniqlo.DAL.Models;
using Uniqlo.MVC.Areas.Admin.ViewModels;


namespace Uniqlo.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderItemController : Controller
    {

        private readonly ISliderItemService _sliderItemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SliderItemController(ISliderItemService sliderItemService, IWebHostEnvironment webHostEnvironment)
        {
            _sliderItemService = sliderItemService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<SliderItem>? SliderItems = _sliderItemService.GetAllSliderItems();
            return View(SliderItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SliderItemCreateVM sliderItemVM)
        {
            if(sliderItemVM.Img is null)
            {
                return View(sliderItemVM);
            }
            if (!ModelState.IsValid)
            {
                return View(sliderItemVM);
            }
            string fileName=Path.GetFileNameWithoutExtension(sliderItemVM.Img.FileName);

            if(sliderItemVM.Img.Length>80*1024)
            {
                ModelState.AddModelError("Img", "Fayl cox boyukdur.");
                return View(sliderItemVM);
            }
            string[] allowedFormat = [".jpg",".png",".jpeg",".svg",".webp"];
            string extension=Path.GetExtension(fileName);
            bool isAllowed = false;
            foreach(var format in allowedFormat)
            {
                if(format==extension)
                {
                    isAllowed = true;
                    break;
                }

            }
            if(!isAllowed)
            {
                ModelState.AddModelError("Img", "icaze yoxdur");
                return View(sliderItemVM);
            }
            string uploadPath =Path.Combine(_webHostEnvironment.WebRootPath,"assets","testFoldre");
            if(Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }





            if(Path.Exists(Path.Combine(uploadPath,fileName+extension)))
            {
                fileName = fileName + Guid.NewGuid().ToString();
            }
            fileName = fileName+extension;


            uploadPath = Path.Combine(uploadPath,fileName);
            using FileStream fileStream=new FileStream(uploadPath,FileMode.Create);
            sliderItemVM.Img.CopyToAsync(fileStream);

            SliderItem sliderItem = new SliderItem()
            {
                ImagePath=fileName
            };
            _sliderItemService.CreateSliderItem(sliderItemVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SliderItem sliderItem = _sliderItemService.GetSliderItemById(id);
            return View(sliderItem);
        }

        [HttpPost]
        public IActionResult Update(int id, SliderItem sliderItem)
        {
            if (!ModelState.IsValid)
            {
                return View(sliderItem);
            }
            _sliderItemService.UpdateSliderItem (id, sliderItem);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _sliderItemService.SoftDeleteSliderItem(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
