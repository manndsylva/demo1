using Microsoft.EntityFrameworkCore;
using WebApplication4.Models.Domain;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class MVCDemoDB : DbContext
    {
        public MVCDemoDB(DbContextOptions<MVCDemoDB> opt) : base(opt)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeModel> EmployeeModel { get; set; }
    }
}
 