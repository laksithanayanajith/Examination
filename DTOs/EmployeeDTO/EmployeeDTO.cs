using Examination.Models;
using System.ComponentModel.DataAnnotations;

namespace Examination.DTOs.EmployeeDTO
{
    public class EmployeeDTO
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string EmpAddressLine1 { get; set; } = string.Empty;
        public string EmpAddressLine2 { get; set; } = string.Empty;
        public string EmpAddressLine3 { get; set; } = string.Empty;
        public string DepartmentID { get; set; } = string.Empty;
        public Department Department { get; set; } = new Department();
        public DateTime DateOfJoin { get; set; } = new DateTime();
        public DateTime DateOfBirth { get; set; } = new DateTime();
        public double BasicSalary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
