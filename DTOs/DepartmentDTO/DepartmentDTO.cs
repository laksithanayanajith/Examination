using Examination.Models;
using System.ComponentModel.DataAnnotations;

namespace Examination.DTOs.DepartmentDTO
{
    public class DepartmentDTO
    {
        public string DepartmentCode { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        //public List<Employee>? Employees { get; set; }
    }
}
