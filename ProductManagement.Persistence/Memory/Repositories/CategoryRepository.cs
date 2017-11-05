using ProductManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Core.Models;

namespace ProductManagement.Persistence.Memory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Category category)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Get()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Get(List<byte> ids)
        {
            throw new NotImplementedException();
        }
    }
}
