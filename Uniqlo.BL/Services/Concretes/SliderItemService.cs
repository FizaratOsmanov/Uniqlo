using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BL.Services.Abstractions;
using Uniqlo.DAL;
using Uniqlo.DAL.Models;
namespace Uniqlo.BL.Services.Concretes
{
    public class SliderItemService:ISliderItemService
    {
        private readonly UniqloDBContext _uniqloDBContext;
        public SliderItemService(UniqloDBContext uniqloDBContext)
        {
            _uniqloDBContext = uniqloDBContext;
        }




        public SliderItem GetSliderItemById(int id)
        {
            SliderItem? sliderItem = _uniqloDBContext.SliderItems.Find(id);
            if (sliderItem is null)
            {
                throw new Exception("SliderItem not found.");
            }

            return sliderItem;
        }

        public IEnumerable<SliderItem> GetAllSliderItems()
        {
            IEnumerable<SliderItem> sliderItems =_uniqloDBContext.SliderItems;
            return sliderItems;
        }

        public  void CreateSliderItem(SliderItem sliderItems)
        {
             _uniqloDBContext.SliderItems.Add(sliderItems);
            int rows = _uniqloDBContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong.");
            }
        }

        public void UpdateSliderItem(int id, SliderItem sliderItem)
        {
            SliderItem? baseSliderItem =  _uniqloDBContext.SliderItems.Find(id);
            sliderItem.ImagePath = sliderItem.ImagePath;
            _uniqloDBContext.SaveChanges();
        }


    }
}
