using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EntityLibrary.Model;

public class Employee : ModelBase
{
    
    public int DepartmentID { get; set; }
    [Column(TypeName = "varchar(25)")] public string FullName { get; set; }
    [Column(TypeName = "varchar(25)")] public string Email { get; set; }
    [ForeignKey("DepartmentID")] public Department Department { get; set; }
}