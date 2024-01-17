namespace Web_API.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public int DepartmentID { get; set; }
    public Department Department { get; set; }
}