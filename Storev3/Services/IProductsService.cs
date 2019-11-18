using Storev3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storev3.Services
{
    public interface IProductsService
    {
        ICollection<Product> GetAll();
        Product GetProduct(Guid id);
        Product AddProduct(string Name);

    }
}
