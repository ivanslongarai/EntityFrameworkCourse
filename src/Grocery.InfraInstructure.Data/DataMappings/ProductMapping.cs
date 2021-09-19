using Grocery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Data.DataMappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT")
                .HasOne(n=> n.Stock)
                .WithOne(n=> n.Product)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Stock>(f => f.ProductId);

            builder.HasMany(n=> n.Categories)
                .WithMany(n=> n.Products);
                
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();                                             
        }
    }
}
