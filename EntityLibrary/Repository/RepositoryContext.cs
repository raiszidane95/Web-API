using EntityLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityLibrary.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Department> Department { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Department>(e =>
        {
            e.HasKey(c => c.DepartmetId);
            e.Property(c => c.DepartmentName).IsRequired(true);
            e.Property(c => c.DepartmentDescription).IsRequired(false);
            e.HasMany(e => e.Employee);
        });
        
        modelBuilder.Entity<Employee>(e =>
        {
            e.HasKey(c => c.EmployeeId);
            e.Property(c => c.FullName).IsRequired(true);
            e.Property(c => c.Email).IsRequired(false);
        });
        
        // modelBuilder.Entity<Category>().HasData
        // (
        //     new Category() 
        //     {
        //         CategoryId = 1,
        //         CategoryName = "Electronic",
        //         Description = "Ini electronic"
        //     },
        //     new Category() 
        //     {
        //         CategoryId = 2,
        //         CategoryName = "Fruit",
        //         Description = "Ini Fruit"
        //     }
        // );
        // modelBuilder.Entity<Product>().HasData
        // (
        //     new Product() 
        //     {
        //         ProductId = 1,
        //         ProductName = "TV",
        //         Description = "Ini TV",
        //         CategoryId = 1
        //     },
        //     new Product() 
        //     {
        //         ProductId = 2,
        //         ProductName = "HP",
        //         Description = "Ini HP",
        //         CategoryId = 1
        //     }
        // );
    }

}