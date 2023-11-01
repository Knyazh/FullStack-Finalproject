using Electro_Ecommerce_MVC_Project.Database.Base;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

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

   

        base.OnModelCreating(modelBuilder);
    }


    //public DbSet<Product> Products { get; set; }
}
