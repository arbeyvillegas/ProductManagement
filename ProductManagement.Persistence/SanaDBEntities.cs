namespace ProductManagement.Persistence
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SanaDBEntities : DbContext
    {
        public SanaDBEntities()
            : base("name=SanaDBEntities")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("ProductXCategories").MapLeftKey("CategoryId").MapRightKey("ProductId"));

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);
        }
    }
}
