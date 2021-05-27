using DataAccessLayer.DataLogic;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataAccessLayer.Controllers
{
    public class HomeController : Controller
    {
        public readonly EmployeeLogic employeeLogic = new EmployeeLogic();
        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {    
            List<EmployeeDTO> employees = employeeLogic.GetEmployees().Result;
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorDTO { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}