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
    public class ProductService : IProductService
    {
        private readonly UniqloDBContext _uniqloDbContext;
        public ProductService(UniqloDBContext uniqloDBContext)
        {
            _uniqloDbContext = uniqloDBContext;
        }

        public Product GetProductById(int id)
        {
            Product? product = _uniqloDbContext.Products.Find(id);
            if (product is null)
            {
                throw new Exception("Product not found.");
            }

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = _uniqloDbContext.Products;
            return products;
        }

        public void CreateProduct(Product product)
        {
            _uniqloDbContext.Products.Add(product);
            int rows = _uniqloDbContext.SaveChanges();

            if (rows != 1)
            {
                throw new Exception("Something went wrong.");
            }
        }

        public void UpdateProduct(int id, Product product)
        {
            Product? baseProduct = _uniqloDbContext.Products.Find(id);
            product.ProductName = product.ProductName;
            _uniqloDbContext.SaveChanges();
        }
    }
}
