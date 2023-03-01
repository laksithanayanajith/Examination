using Examination.DTOs.DepartmentDTO;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetDepartment();

        Task<DepartmentDTO?> GetDepartment(string id);

        Task<List<Department>?> PutDepartment(string id, [FromBody] Department department);

        Task<List<Department>> PostDepartment([FromBody] CreateDepartmentDTO createDepartmentDTO);

        Task<List<Department>?> DeleteDepartment(string id);
    }
}
