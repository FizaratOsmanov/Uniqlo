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
    public class CategoryService : ICategoryService
    {

        private readonly UniqloDBContext _uniqloDbContext;
        public CategoryService(UniqloDBContext uniqloDBContext)
        {
            _uniqloDbContext = uniqloDBContext;
        }





        public Category GetCategoryById(int id)
        {
            Category? category = _uniqloDbContext.Categories.Find(id);
            if (category is null)
            {
                throw new Exception("Category not found.");
            }

            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> categories = _uniqloDbContext.Categories;
            return categories;
        }

        public void CreateCategory(Category category)
        {
            _uniqloDbContext.Categories.Add(category);
            int rows = _uniqloDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong.");
            }
        }


        public void UpdateCategory(int id, Category category)
        {
            Category? baseCategory = _uniqloDbContext.Categories.Find(id);
            baseCategory.CategoryName =category.CategoryName;
            _uniqloDbContext.SaveChanges();
        }

        public void SoftDeleteCategory(int id)
        {
            Category? baseCategory = _uniqloDbContext.Categories.SingleOrDefault(s => s.Id == id);
            if (baseCategory is null)
            {
                throw new Exception($"Category not found.");
            }
            baseCategory.IsDeleted = true;
            baseCategory.DeleteDate = DateTime.Now;

            _uniqloDbContext.SaveChanges();

        }

        public void HardDeleteCategory(int id)
        {


            Category? baseCategory = _uniqloDbContext.Categories.Find(id);
            if (baseCategory is null)
            {
                throw new Exception($"Category not found with this id({id})");
            }

            _uniqloDbContext.Categories.Remove(baseCategory);
        }

    }
}
