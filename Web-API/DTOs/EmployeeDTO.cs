namespace Web_API.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public int DepartmentID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DepartmentDTO? Department { get; set; }
}