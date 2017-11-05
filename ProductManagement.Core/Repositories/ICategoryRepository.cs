using ProductManagement.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Core.Repositories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Get();
        IQueryable<Category> Get(List<byte> ids);
        void Add(Category category);
    }
}
