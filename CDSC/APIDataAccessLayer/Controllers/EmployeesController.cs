using DataAccessLayer.DataLogic;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIDataAccessLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly EmployeeLogic employeeLogic = new EmployeeLogic();
        public EmployeesController()
        {
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            List<EmployeeDTO> employeesFromDatabase = employeeLogic.GetEmployees().Result;
            return Ok(employeesFromDatabase);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            EmployeeDTO employeeFromDatabase = employeeLogic.GetEmployeeById(id).Result;
            bool validateIfDataIsNull = employeeFromDatabase == null;
            if (validateIfDataIsNull)
            {
                return NotFound();
            }
            return Ok(employeeFromDatabase);
        }
    }
}