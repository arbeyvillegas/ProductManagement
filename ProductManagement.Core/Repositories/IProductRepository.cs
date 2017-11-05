using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int id);
        void Add(Product product);

    }
}
