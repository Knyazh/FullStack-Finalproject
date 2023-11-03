using Electro_Ecommerce_MVC_Project.Database.Base;
using Electro_Ecommerce_MVC_Project.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Electro_Ecommerce_MVC_Project.Database;

public class EcommerceDbContext : DbContext
{

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
       : base(options) { }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not IAuditable)
                continue;

            IAuditable auditable = (IAuditable)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                auditable.CreatedAt = DateTime.UtcNow;
                auditable.UpdatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                auditable.UpdatedAt = DateTime.UtcNow;
            }
        }


        return base.SaveChanges();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);

        #region Colors
        modelBuilder.Entity<Color>().HasData
            (
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -7,
                    Name = "Yellow",
                    Code = "#fbff00"
                },

       
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -5,
                    Name = "Black",
                    Code = "#000000"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -4,
                    Name = "Gray",
                    Code = "#666666"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -3,
                    Name = "Blue",
                    Code = "#0052d6"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -2,
                    Name = "White",
                    Code = "#ffffff"
                },
                new Color
                {
                    UpdatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    CreatedAt = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                    Id = -1,
                    Name = "Red",
                    Code = "#ff0000"
                }
                );
        #endregion

        #region Categires


        modelBuilder.Entity<Category>().HasData
            (
            new Category
            {
                Id = -10,
                Name = "Laptop",
                Description = " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display," +
                " a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos" +
                ". With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Category
            {
                Id = -9,
                Name = "Phone",
                Description = " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display," +
                " a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos" +
                ". With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Category
            {
                Id = -8,
                Name = "SmartWatches",
                Description = " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display," +
                " a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos" +
                ". With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc)
            },
            new Category
            {
                Id = -7,
                Name = "4k Smart Tv",
                Description = " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display," +
                " a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos" +
                ". With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc)
            },
            new Category
            {
                Id = -6,
                Name = "Gaming Consoles",
                Description = " The iPhone 13 Pro is Apple's flagship smartphone, offering a stunning Super Retina XDR display," +
                " a powerful A15 Bionic chip, and a versatile triple-camera system for capturing high-quality photos and videos" +
                ". With 5G connectivity, Face ID, and the latest iOS features, it's a top choice for those who demand performance and cutting-edge technology.",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc)
            }

            );

        #endregion

        #region Memory

        modelBuilder.Entity<Memory>().HasData
            (
            new Memory
            {
                Id = -5,
                Count = "64 GB",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Memory
            {
                Id = -4,
                Count = "128 GB",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Memory
            {
                Id = -3,
                Count = "256 GB",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Memory
            {
                Id = -2,
                Count = "512GB",
                UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            },
            new Memory
            {
                 Id = -1,
                 Count = "1 TB",
                 UpdatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
                 CreatedDate = new DateTime(2023, 10, 19, 0, 0, 0, DateTimeKind.Utc),
            }
            );
        #endregion

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Memory> Memories { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductMemory> ProductMemories { get; set; }







}
