using Electro_Ecommerce_MVC_Project.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electro_Ecommerce_MVC_Project.Database.Configurations;

public class ProductMemoryConfiguration : IEntityTypeConfiguration<ProductMemory>
{
    public void Configure (EntityTypeBuilder<ProductMemory> builder)
    {
        builder
            .HasKey(pm=> new { pm.ProductId,pm.MemoryId});

        builder
                .HasOne(pm => pm.Product)
                .WithMany(p => p.ProductMemories)
                .HasForeignKey(pm => pm.ProductId);

        builder
               .HasOne(pm => pm.Memory)
               .WithMany(p => p.ProductMemories)
               .HasForeignKey(pm => pm.MemoryId);
    }

}
