using AutoMapper;
using EntityLibrary.Model;
using EntityLibrary.Repository;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.DTOs;

namespace Web_API.Controllers;

public class EmployeeController : APIBaseController
{
    private readonly RepositoryContext _db;
    private readonly IMapper _map;
    public EmployeeController(RepositoryContext myDatabase, IMapper map) 
    {
        _map = map;
        _db = myDatabase;
    }
    [HttpGet]
    public async Task<IActionResult> GetEmployee()
    {
        IQueryable<Employee> categories;
      
        categories = _db.Employee;
        if(!categories.Any()) 
        {
            return NotFound();
        }
        List<EmployeeDTO> response = _map.Map<List<EmployeeDTO>>(categories); 
        return Ok(response);
    }
}