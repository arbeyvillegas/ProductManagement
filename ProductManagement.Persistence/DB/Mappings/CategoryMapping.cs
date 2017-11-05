using ProductManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ProductManagement.Persistence.DB.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            this.ToTable("Categories");

            this.HasKey(e => e.Id);

            this.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            this.HasMany<Product>(c => c.Products)
                .WithMany(p => p.Categories)
                .Map(cp =>
                {
                    cp.MapLeftKey("CategoryId");
                    cp.MapRightKey("ProductId");
                    cp.ToTable("ProductXCategories");
                });
        }
    }
}
