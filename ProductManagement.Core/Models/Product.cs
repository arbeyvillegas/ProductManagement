using System.Collections.Generic;

namespace ProductManagement.Core.Models
{
    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
