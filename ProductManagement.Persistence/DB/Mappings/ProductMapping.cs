using ProductManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace ProductManagement.Persistence.DB.Mappings
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            this.ToTable("Products");

            this.HasKey(e => e.Id);

            this.Property(e => e.Title)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(e => e.Description)
               .HasMaxLength(500);

            this.Property(e => e.Price)
               .HasPrecision(10, 2);

            this.HasMany<Category>(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(pc =>
                    {
                        pc.MapLeftKey("ProductId");
                        pc.MapRightKey("CategoryId");
                        pc.ToTable("ProductXCategories");
                    });
        }
    }
}
