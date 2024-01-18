using AutoMapper;
using EntityLibrary.Model;
using EntityLibrary.Repository;
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
    [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEmployee()
    {
        IQueryable<Employee> employees;
      
        employees = _db.Employee.Include(e => e.Department);
        if(!employees.Any()) 
        {
            return NotFound();
        }
        List<EmployeeDTO> response = _map.Map<List<EmployeeDTO>>(employees); 
        return Ok(response);
    }
    
    [HttpGet("id")]
    [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        Employee? employee;
        employee = await _db.Employee.FindAsync(id);
        EmployeeDTO response = _map.Map<EmployeeDTO>(employee); 
        return response == null ? NotFound() : Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddEmployee([FromQuery] EmployeeDTO employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (employeeDto.DepartmentID == null)
        {
            ModelState.AddModelError(nameof(employeeDto.DepartmentID), "DepartmentID is Required");
            return BadRequest(ModelState);
        }
        
        if (employeeDto.Department != null)
        {
            if (employeeDto.Department.Id == null)
            {
                employeeDto.Department.Id = employeeDto.DepartmentID;

                if (employeeDto.DepartmentID != employeeDto.Department.Id)
                {
                    ModelState.AddModelError(nameof(employeeDto.DepartmentID), "DepartmentID must match Department.Id");
                    return BadRequest(ModelState);
                }
            }
        }
        try
        {
            var employee = _map.Map<Employee>(employeeDto);
            await _db.Employee.AddAsync(employee);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { employeeDto });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateEmployeeById(int id, [FromQuery] EmployeeDTO employeeDto)
    {
        if (id != employeeDto.Id)
        {
            return BadRequest("ID in the URL does not match ID in the request body.");
        }

        try
        {
            Employee employee = await _db.Employee.FindAsync(id);
            
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            _map.Map(employeeDto, employee);
            await _db.SaveChangesAsync();
            EmployeeDTO response = _map.Map<EmployeeDTO>(employee);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(EmployeeDTO), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        Employee? employee;
        employee = await _db.Employee.FindAsync(id);
        if (employee == null) return NotFound();
        
        _db.Remove(employee);
        await _db.SaveChangesAsync();
        EmployeeDTO response = _map.Map<EmployeeDTO>(employee); 
        return Ok(response);
    }
}