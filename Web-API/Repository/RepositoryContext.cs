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
            e.HasKey(c => c.Id);
            e.Property(c => c.DepartmentName).IsRequired(true);
            e.Property(c => c.DepartmentDescription).IsRequired(false);
            e.HasMany(e => e.Employee);
        });
        
        modelBuilder.Entity<Employee>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.FullName).IsRequired(true);
            e.Property(c => c.Email).IsRequired(false);
        });
        
        modelBuilder.Entity<Department>().HasData
        (
            new Department() 
            {
                Id= 1,
                DepartmentName = "Software Engineer",
                DepartmentDescription = "Software Engineering"
            },new Department() 
            {
                Id= 2,
                DepartmentName = "Electrical Engineer",
                DepartmentDescription = "Electrical Engineering"
            }
           
        );
        modelBuilder.Entity<Employee>().HasData
        (
            new Employee() 
            {
                Id = 1,
                FullName= "Dody Kurniawan",
                Email = "dody@company.com",
                DepartmentID = 1
            }, new Employee() 
            {
                Id = 2,
                FullName= "Rei Santoso",
                Email = "rei@company.com",
                DepartmentID = 2
            }
            
        );
    }

}