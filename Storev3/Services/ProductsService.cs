using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Storev3.Models;

namespace Storev3.Services
{
    public class ProductsService : IProductsService
    {
        private readonly List<Product> products = new List<Product>();
        public ProductsService()
        {
            for (int i = 0; i < 8; i++)
            {
                products.Add(new Product { Id = Guid.NewGuid(), Name = $"Product {i}" });
            }
        }



        public ICollection<Product> GetAll()
        {
            return products;
        }
        public Product GetProduct(Guid id)
        {
            return products.SingleOrDefault(x => x.Id == id);
            
        }

         public Product AddProduct(string Name)
        {
            var product = (new Product { Id = Guid.NewGuid(), Name = $"Product {Name}" });
            products.Add(product);
            return product;
        }
    }
}
