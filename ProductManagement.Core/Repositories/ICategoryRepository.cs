using ProductManagement.Core.Models;
using System.Collections.Generic;

namespace ProductManagement.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        void Add(Category Category);
    }
}
