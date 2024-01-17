

using EntityLibrary.Model;

public class Department 
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentDescription { get; set; }
    
    public virtual ICollection<Employee> Employee { get; set; }
    public Department() 
    {
        Employee = new HashSet<Employee>(); 
    }
}
