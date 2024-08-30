using System.ComponentModel.DataAnnotations;

namespace EmployeeDetails.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Range(100000,500000)]
        public int Salary { get; set; }
        public string searchTerm { get; set; }
    }
}
