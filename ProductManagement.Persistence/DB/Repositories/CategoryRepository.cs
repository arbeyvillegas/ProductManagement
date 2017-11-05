using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using ProductManagement.Persistence.DB.Contexts;
using System.Collections.Generic;

namespace ProductManagement.Persistence.DB.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IContext _context;

        public CategoryRepository(IContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.Complete();
        }

        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }
    }
}
