using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Ordering.Data.Models;

namespace OnlineStore.Ordering.Data.Configurations
{
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder
                .HasKey(c => c.Id);
            
            builder
                .Property(c => c.ProductId); 
            
            builder
                .Property(c => c.Quantity);

            builder
                .HasOne(c => c.Order)
                .WithMany(c => c.OrderLines)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
