using ProductManagement.Core.Enumerations;
using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace ProductManagement.Persistence.Memory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static ICollection<Product> Products;

        private IUnityContainer _container;

        public ProductRepository(IUnityContainer container)
        {
            if (Products == null)
                Products = new List<Product>();

            _container = container;
        }

        public void Add(Product product, byte[] categoryIds)
        {
            var categoryRepository = _container.Resolve<ICategoryRepository>(nameof(EStorageType.Memory));

            product.Id = GetNextSequence();

            if (categoryIds != null && categoryIds.Length > 0)
                product.Categories = (from category in categoryRepository.Get(categoryIds.ToList())
                                      select new Category()
                                      {
                                          Id = category.Id,
                                          Name = category.Name
                                      }).ToList();

            Products.Add(product);
        }

        public IQueryable<Product> Get()
        {
            return Products.AsQueryable();
        }

        public Product Get(int id)
        {
            return Products.Where(p => p.Id == id).FirstOrDefault();
        }

        private int GetNextSequence()
        {
            int maxId = 0;

            if (Products.Count > 0)
                maxId = Products.Max(c => c.Id);

            return ++maxId;
        }
    }
}
