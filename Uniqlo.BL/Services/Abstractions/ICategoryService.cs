using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        public Category GetCategoryById(int id);
        public IEnumerable<Category> GetAllCategories();
        public void CreateCategory(Category category);
        public void UpdateCategory(int id, Category category);

    }
}
