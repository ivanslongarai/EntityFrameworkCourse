using Grocery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Data.DataMappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORY");
            builder.Property(p=> p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();

            builder.Property(p=> p.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
