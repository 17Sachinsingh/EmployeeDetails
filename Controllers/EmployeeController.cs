using EmployeeDetails.Data;
using EmployeeDetails.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public EmployeeController(DatabaseContext databaseContext)
        {
                _databaseContext= databaseContext;
        }
       
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add( AddEmployee employeeModel)
        {
            var employee = new Employee
            {
                EmployeeName = employeeModel.EmployeeName,
                Salary = employeeModel.Salary
            };
            await _databaseContext.employees.AddAsync(employee);
            await _databaseContext.SaveChangesAsync();
            return View();
           
        }
        [HttpGet]
        public async Task<IActionResult> List(string searchString)
        {
            var employees = await _databaseContext.employees.ToListAsync();
            if (searchString is not null)
            {
                var filteredEmployee=new List<Employee>();
                foreach(var employee in employees)
                {
                    if (employee.EmployeeName.Contains(searchString))
                    {
                        filteredEmployee.Add(employee);
                    }
                }
                //return View(filteredEmployee);
                employees= filteredEmployee;
            }

            
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id )
        {
            var employee =await _databaseContext.employees.FindAsync(id);
            return View(employee);
        }
        
    }
}
