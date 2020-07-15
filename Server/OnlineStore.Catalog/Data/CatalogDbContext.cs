using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Catalog.Data.Models;
using OnlineStore.Common.Data;

namespace OnlineStore.Catalog.Data
{
    public class CatalogDbContext : MessageDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override Assembly ConfigurationsAssembly
            => Assembly.GetExecutingAssembly();
    }
}
