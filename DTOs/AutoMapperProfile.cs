using AutoMapper;
using Examination.DTOs.DepartmentDTO;
using Examination.DTOs.EmployeeDTO;
using Examination.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Examination.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeDTO.EmployeeDTO, Employee>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>();

            CreateMap<DepartmentDTO.DepartmentDTO, Department>().ReverseMap();
            CreateMap<CreateDepartmentDTO, Department>();
        }
    }
}
