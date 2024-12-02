using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DAL.Models;

namespace Uniqlo.DAL
{
    public class UniqloDBContext : DbContext
    {
        public UniqloDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SliderItem> SliderItems;
        public DbSet<Category> Categories;
        public DbSet<Product> Products;
        
    }
}
