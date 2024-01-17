using AutoMapper;
using EntityLibrary.Model;
using Web_API.DTOs;

namespace Web_API.Map;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Department, DepartmentDTO>();
    }
}