using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Models.Domain;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MVCDemoDB mvcdemodata;
        public EmployeeController(MVCDemoDB mvcdemodata) 
        {
            this.mvcdemodata = mvcdemodata;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.TotalEmployees = mvcdemodata.Employees.Count();
            var emp = await mvcdemodata.Employees.ToListAsync();
            return View(emp);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = addEmployeeRequest.Id,
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                date = addEmployeeRequest.date,
                dept = addEmployeeRequest.dept,
            };
            await mvcdemodata.Employees.AddAsync(employee);
            await mvcdemodata.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var emp=await mvcdemodata.Employees.FirstOrDefaultAsync(s => s.Id == id);
            if (emp != null)
            {
                var employee = new UpdateEmployeeModel()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Salary = emp.Salary,
                    date = emp.date,
                    dept = emp.dept,
                };
                return View(employee);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(UpdateEmployeeModel model)
        {
            var employee = await mvcdemodata.Employees.FindAsync(model.Id);
            if(employee != null)
            {
                employee.Id = model.Id;
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.date = model.date;
                employee.dept = model.dept;

                mvcdemodata.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(UpdateEmployeeModel model)
        {
            var employee = await mvcdemodata.Employees.FindAsync(model.Id);
            
            if (employee != null)
            {
                mvcdemodata.Employees.Remove(employee);
                await mvcdemodata.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
