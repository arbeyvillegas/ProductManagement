using ProductManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Core.Models;

namespace ProductManagement.Persistence.Memory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product, byte[] categoryIds)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
