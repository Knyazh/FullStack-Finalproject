using Electro_Ecommerce_MVC_Project.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electro_Ecommerce_MVC_Project.Database.Configurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{

    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder
              .HasKey(pc => new { pc.ProductId, pc.ColorId });

        builder
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductColors)
            .HasForeignKey(pc => pc.ProductId);

        builder
            .HasOne(pc => pc.Color)
            .WithMany(p => p.ProductColors)
            .HasForeignKey(pc => pc.ColorId);
    }

}
