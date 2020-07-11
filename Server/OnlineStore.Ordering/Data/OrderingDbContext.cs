using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Ordering.Data.Models;

namespace OnlineStore.Ordering.Data
{
    public class OrderingDbContext : DbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
