using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using ProductManagement.Persistence.DB.Contexts;
using System.Collections.Generic;
using System.Linq;

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

        public IQueryable<Category> Get()
        {
            return _context.Categories;
        }

        public IQueryable<Category> Get(List<byte> ids)
        {
            return _context.Categories.Where(c => ids.Contains(c.Id));
        }
    }
}
