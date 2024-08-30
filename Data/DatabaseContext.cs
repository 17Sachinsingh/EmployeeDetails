using Microsoft.EntityFrameworkCore;
using EmployeeDetails.Models;
namespace EmployeeDetails.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        public  DbSet<Employee> employees { get; set; }
    }
}
