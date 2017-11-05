using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        void Add(Product Category);
    }
}
