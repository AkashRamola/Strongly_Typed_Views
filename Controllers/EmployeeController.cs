using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strongly_Typed_Views.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Strongly_Typed_Views.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmplpyeeDbContext _context;
        public EmployeeController(ILogger<EmployeeController> logger, EmplpyeeDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }
        public async Task<IActionResult> ViewEmployee(int id)
        {
            Employee employee = new Employee();
            employee = await _context.Employees.FirstOrDefaultAsync(d => d.Id == id);
            if (employee == null)
            {
                return Content("Record not found");
            }
            return View(employee);
        }
        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromForm] Employee Data)
        {
            if (Data.Name == null || Data.Role==null || Data.Salary==0)
                return BadRequest("Data field may be null");
            await _context.Employees.AddAsync(Data);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Employee added successfully."
            });
        }
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            Employee employee = new Employee();
            employee = await _context.Employees.FirstOrDefaultAsync(d => d.Id == id);
            if (employee == null)
            {
                return Content("Record not found");
            }
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee([FromForm] Employee Data)
        {
            if (Data == null)
            {
                return BadRequest("Employee data is required.");
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(d => d.Id == Data.Id);
            employee.Name = Data.Name;
            employee.Role = Data.Role;
            employee.Salary = Data.Salary;

            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Employee '{Name}' was updated successfully.",
                employee.Name);

            return Ok(new
            {
                success = true,
                message = "Employee updated successfully."
            });
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            Employee employee = new Employee();
            employee = await _context.Employees.FirstOrDefaultAsync(d => d.Id == id);
            if (employee == null)
            {
                return Content("Record not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Employee '{Name}' was deleted successfully.", employee.Name);
            return RedirectToAction("Index", "Employee");
        }
    }
}
