using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Common.Data;

namespace OnlineStore.Payment.Data
{
    public class PaymentDbContext : MessageDbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Payment> Payments { get; set; }

        protected override Assembly ConfigurationsAssembly
            => Assembly.GetExecutingAssembly();
    }
}
