using ProductManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Core.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
        Product Get(int id);
        void Add(Product product, byte[] categoryIds);

    }
}
