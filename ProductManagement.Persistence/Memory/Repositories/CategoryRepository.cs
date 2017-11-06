using ProductManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using ProductManagement.Core.Models;

namespace ProductManagement.Persistence.Memory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private static ICollection<Category> Categories;

        public CategoryRepository()
        {
            if (Categories == null)
                Categories = new List<Category>();
        }

        public void Add(Category category)
        {

            category.Id = GetNextSequence();

            Categories.Add(category);
        }

        public IQueryable<Category> Get()
        {
            return Categories.AsQueryable();
        }

        public IQueryable<Category> Get(List<byte> ids)
        {
            return Categories.Where(c => ids.Contains(c.Id)).AsQueryable();
        }

        private byte GetNextSequence()
        {
            byte maxId = 0;

            if (Categories.Count > 0)
                maxId = Categories.Max(c => c.Id);

            return ++maxId;
        }
    }
}
