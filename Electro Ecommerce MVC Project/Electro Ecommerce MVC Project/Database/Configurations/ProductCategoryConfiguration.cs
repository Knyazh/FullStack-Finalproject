﻿using Electro_Ecommerce_MVC_Project.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Electro_Ecommerce_MVC_Project.Database.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
       builder.HasKey
            (pc=> new {pc.ProductId, pc.CategoryId});

        builder
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId);

        builder
            .HasOne(pc => pc.Category)
            .WithMany(c=>c.ProductCategories)
            .HasForeignKey(pc=>pc.CategoryId);


    }
}
