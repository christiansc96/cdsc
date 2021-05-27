using DataAccessLayer.DataLogic;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeLogic employeeLogic = new EmployeeLogic();
        public IActionResult Index()
        {
            return View();
        }
    }
}