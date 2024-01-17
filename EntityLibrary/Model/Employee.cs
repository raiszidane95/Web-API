using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLibrary.Model;

public class Employee 
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int DepartmentID { get; set; }
    [ForeignKey("DepartmentID")] 
    public Department Department { get; set; }
}