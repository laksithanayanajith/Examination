using System.ComponentModel.DataAnnotations;

namespace Examination.Models
{
    public class Department
    {
        [Key]
        [DataType(DataType.Text, ErrorMessage = "You must enter text only!")]
        [MaxLength(4, ErrorMessage = "You can enter only 4 letters maximum!")]
        [MinLength(2, ErrorMessage = "You can enter only 2 letters minimum!")]
        [StringLength(4)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "This does not like a valid department code!")]
        [Required(ErrorMessage = "Department code is required!")]
        public string DepartmentCode { get; set; } = string.Empty;

        [DataType(DataType.Text, ErrorMessage = "You must enter text only!")]
        [MaxLength(60, ErrorMessage = "You can enter only 60 letters maximum!")]
        [MinLength(10, ErrorMessage = "You can enter only 10 letters minimum!")]
        [StringLength(60)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "This does not like a valid department name!")]
        [Required(ErrorMessage = "Department name is required!")]
        public string DepartmentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "please mark is active or not!")]
        public bool IsActive { get; set; } = true;

        //public List<Employee>? Employees { get; set; }
    }
}
