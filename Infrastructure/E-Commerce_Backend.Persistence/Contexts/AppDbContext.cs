﻿
namespace E_Commerce_Backend.Persistence.Contexts;

public class AppDbContext:DbContext
{
    /// <summary>
    /// I have created migrations in terminal with this commands:
    /// dotnet ef migrations add InitialCreate
    ///  --project Infrastructure/E-Commerce_Backend.Persistence  
    /// --startup-project Presentation/E-Commerce_Backend.API
    /// </summary>
    
    /// <summary>
    /// Applied commands to root folder of sln file
    /// I have updated database in terminal with this commands:
    /// dotnet ef database update 
    ///  --project Infrastructure/E-Commerce_Backend.Persistence  
    /// --startup-project Presentation/E-Commerce_Backend.API
    /// </summary>
     public AppDbContext()
     {
        
     }

     public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
     {
        
     }

     public DbSet<Brand> Brands { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Detail> Details { get; set; }
     public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}