using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Salary is required")]
        public int? Salary { get; set; } = null;
       
    }
}
