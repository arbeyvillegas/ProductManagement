using ProductManagement.Core.Models;
using ProductManagement.Persistence.DB.Mappings;
using System.Data.Entity;

namespace ProductManagement.Persistence.DB.Contexts
{
    public class Context : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public Context() : base("name=SanaDBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
        }
    }
}
