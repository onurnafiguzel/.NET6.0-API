using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities;
using System.Reflection;

namespace NLayer.Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Veritabanı yolu startup'tan verilecek
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Configuration dsoyalarını okur
            base.OnModelCreating(modelBuilder);
        }
    }
}
