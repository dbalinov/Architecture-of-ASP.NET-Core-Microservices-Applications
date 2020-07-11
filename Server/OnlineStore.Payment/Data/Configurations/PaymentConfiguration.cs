using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineStore.Payment.Data.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Models.Payment>
    {
        public void Configure(EntityTypeBuilder<Models.Payment> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.OrderId);

            builder
                .Property(c => c.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
