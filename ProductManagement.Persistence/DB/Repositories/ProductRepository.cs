using ProductManagement.Core.Models;
using ProductManagement.Core.Repositories;
using ProductManagement.Persistence.DB.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace ProductManagement.Persistence.DB.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly IContext _context;

        public ProductRepository(IContext context)
        {
            _context = context;
        }

        public void Add(Product product, byte[] categoryIds)
        {
            if (categoryIds != null)
            {
                foreach (var categoryId in categoryIds)
                {
                    var category = new Category()
                    {
                        Id = categoryId
                    };
                    _context.Categories.Attach(category);
                    product.Categories.Add(category);
                }
            }
            _context.Products.Add(product);
            _context.Complete();
        }

        public IQueryable<Product> Get()
        {
            return _context.Products;
        }

        public Product Get(int id)
        {
            return _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Categories)
                .FirstOrDefault();
        }
    }
}
