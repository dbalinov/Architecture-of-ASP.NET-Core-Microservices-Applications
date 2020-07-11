using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Catalog.Data.Models;

using static OnlineStore.Common.Data.DataConstants.Common;

namespace OnlineStore.Catalog.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(c => c.ImageBase64)
                .IsRequired();

            builder
                .Property(c => c.Quantity);

            builder
                .Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            
            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}