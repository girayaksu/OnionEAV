using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Persistence.Configurations
{
    public class ProductAttributeConfiguration : BaseConfiguration<ProductAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DataType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
