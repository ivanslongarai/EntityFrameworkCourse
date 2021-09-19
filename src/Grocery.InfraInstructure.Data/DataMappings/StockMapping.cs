using Grocery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Data.DataMappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("STOCK")
                .OwnsOne(n => n.PurchaseInformation)
                .Property(p=> p.UnitPrice)
                .HasColumnName("UNIT_PRICE")
                .HasPrecision(16,4);

            builder.OwnsOne(n => n.PurchaseInformation)
                .Property(p => p.Quantity)
                .HasColumnName("QUANTITY");

            builder.OwnsOne(n => n.PurchaseInformation)
                .Property(p => p.UnitEnum)
                .HasColumnName("UNIT");

            builder.HasOne(n => n.Product)
                .WithOne(n => n.Stock)
                .HasForeignKey<Stock>(k => k.ProductId);
                
            
        }
    }
}
