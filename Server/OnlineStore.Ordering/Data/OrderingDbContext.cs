using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Data;
using OnlineStore.Ordering.Data.Models;

namespace OnlineStore.Ordering.Data
{
    public class OrderingDbContext : MessageDbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override Assembly ConfigurationsAssembly
            => Assembly.GetExecutingAssembly();
    }
}
