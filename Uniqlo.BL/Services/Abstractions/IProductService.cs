using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DAL.Models;

namespace Uniqlo.BL.Services.Abstractions
{
    public interface IProductService
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(Product product);
        public void UpdateProduct(int id, Product product);
        public void SoftDeleteProduct(int id);
        public void HardDeleteProduct(int id);
    }
}
