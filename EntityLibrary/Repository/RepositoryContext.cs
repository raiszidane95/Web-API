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
            e.HasKey(c => c.DepartmentId);
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
        
        modelBuilder.Entity<Department>().HasData
        (
            new Department() 
            {
                DepartmentId= 1,
                DepartmentName = "Software Engineer",
                DepartmentDescription = "Software Engineering"
            },new Department() 
            {
                DepartmentId= 2,
                DepartmentName = "Electrical Engineer",
                DepartmentDescription = "Electrical Engineering"
            }
           
        );
        modelBuilder.Entity<Employee>().HasData
        (
            new Employee() 
            {
                EmployeeId = 1,
                FullName= "Dody Kurniawan",
                Email = "dody@company.com",
                DepartmentID = 1
            }, new Employee() 
            {
                EmployeeId = 2,
                FullName= "Rei Santoso",
                Email = "rei@company.com",
                DepartmentID = 2
            }
            
        );
    }

}