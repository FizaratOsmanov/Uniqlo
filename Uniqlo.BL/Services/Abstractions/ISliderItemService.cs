using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Abstractions
{
    public interface ISliderItemService
    {
        public SliderItem GetSliderItemById(int id);
        public IEnumerable<SliderItem> GetAllSliderItems();
        public void CreateSliderItem(SliderItem sliderItem);
        public void UpdateSliderItem(int id, SliderItem sliderItem);
        public void SoftDeleteSliderItem(int id);
        public void HardDeleteSliderItem(int id);

    }
}
