using Examination.Models;
using System.ComponentModel.DataAnnotations;

namespace Examination.DTOs.EmployeeDTO
{
    public class CreateEmployeeDTO
    {

        [DataType(DataType.Text, ErrorMessage = "You must enter text only!")]
        [MaxLength(80, ErrorMessage = "You can enter only 80 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "This does not like a name!")]
        [Required(ErrorMessage = "Employer name is required!")]
        public string EmpName { get; set; } = string.Empty;

        [DataType(DataType.Text, ErrorMessage = "You cannot enter any symbols!")]
        [MaxLength(60, ErrorMessage = "You can enter only 60 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z\s0-9]+(\/[0-9]+)*$", ErrorMessage = "This does not like a valid first address line!")]
        [Required(ErrorMessage = "First address line is required!")]
        public string EmpAddressLine1 { get; set; } = string.Empty;

        [DataType(DataType.Text, ErrorMessage = "You cannot enter any symbols!")]
        [MaxLength(180, ErrorMessage = "You can enter only 180 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(180)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "This does not like a valid second address line!")]
        [Required(ErrorMessage = "Second address line is required!")]
        public string EmpAddressLine2 { get; set; } = string.Empty;


        [DataType(DataType.Text, ErrorMessage = "You cannot enter any symbols!")]
        [MaxLength(180, ErrorMessage = "You can enter only 180 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(180)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "This does not like a valid second address line!")]
        public string EmpAddressLine3 { get; set; } = string.Empty;


        [DataType(DataType.Text, ErrorMessage = "You must enter text only!")]
        [MaxLength(4, ErrorMessage = "You can enter only 4 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(4)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "This does not like a valid department code!")]
        [Required(ErrorMessage = "Department code is required!")]
        public string? DepartmentID { get; set; } = string.Empty;
        //public Department Department { get; set; } = new Department();


        [DataType(DataType.DateTime, ErrorMessage = "You must enter vslid Date and Time only!")]
        [Required(ErrorMessage = "Date and Time is required!")]
        public DateTime DateOfJoin { get; set; } = new DateTime();

        [DataType(DataType.DateTime, ErrorMessage = "You must enter vslid Date and Time only!")]
        [Required(ErrorMessage = "Date of Birth is required!")]
        public DateTime DateOfBirth { get; set; } = new DateTime();

        [RegularExpression(@"^[0-9]*[.]?[0-9]+$", ErrorMessage = "This does not like a valid basic salary!")]
        [Required(ErrorMessage = "Basic salary is required!")]
        public double BasicSalary { get; set; }

        [Required(ErrorMessage = "please mark is active or not!")]
        public bool IsActive { get; set; } = true;
    }
}
