using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Strongly_Typed_Views.Models;

namespace Strongly_Typed_Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Employee emp = new Employee()
            //{
            //    Id = 1,
            //    Name = "Aryan",
            //    Role = "SDE",
            //    Salary = 30000
            //};
            //var emp = new List<Employee>
            //{
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "Aryan",
            //        Role = "SDE",
            //        Salary = 60000
            //    },
            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "Ayush",
            //        Role = "EE",
            //        Salary = 40000
            //    },
            //    new Employee
            //    {
            //        Id = 3,
            //        Name = "Tushar",
            //        Role = "CE",
            //        Salary = 50000
            //    }
            //};
            return View();
        }
        public IActionResult EmployeeForm()
        {

            return View();
        }
        [HttpPost]
        public IActionResult EmployeeForm(Employee emp)
        {
            Employee emp1 = new Employee
            {
                Id = emp.Id,
                Name=emp.Name,
                Role=emp.Role,
                Salary=emp.Salary
            };
            return View("Show", emp1);
        }
        public IActionResult Show()
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
