using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionEAV.Domain.Entities;

namespace OnionEAV.Persistence.Configurations
{
    public class ProductAttributeValueConfiguration : BaseConfiguration<ProductAttributeValue>
    {
        public override void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.AttributeValues)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ProductAttribute)
                .WithMany(x => x.ProductAttributeValues)
                .HasForeignKey(x => x.ProductAttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.ProductId, x.ProductAttributeId })
                .IsUnique();
        }
    }
}
