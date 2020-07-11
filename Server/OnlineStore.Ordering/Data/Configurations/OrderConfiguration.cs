using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Ordering.Data.Models;
using static OnlineStore.Ordering.Data.DataConstants.Orders;

namespace OnlineStore.Ordering.Data.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(d => d.UserId)
                .IsRequired()
                .HasMaxLength(MaxUserIdLength);

            builder
                .Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(MaxPhoneNumberLength);

            builder
                .Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(MaxAddressLength);

            builder
                .Property(d => d.Status)
                .IsRequired();
        }
    }
}
