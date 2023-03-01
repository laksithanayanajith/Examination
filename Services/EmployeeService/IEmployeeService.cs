using Examination.DTOs.EmployeeDTO;
using Examination.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examination.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetEmployee();

        Task<EmployeeDTO?> GetEmployee(int id);

        Task<List<Employee>?> PutEmployee(int id, [FromBody] Employee employee);

        Task<List<Employee>> PostEmployee([FromBody] CreateEmployeeDTO createEmployeeDTO);

        Task<List<Employee>?> DeleteEmployee(int id);
    }
}
