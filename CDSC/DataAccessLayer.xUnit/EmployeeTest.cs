using DataAccessLayer.DataLogic;
using Xunit;

namespace DataAccessLayer.xUnit
{
    public class EmployeeTest
    {
        public readonly EmployeeLogic employeeLogic = new EmployeeLogic();

        [Fact]
        public void EmployeesCount()
        {
            var getEmployees = employeeLogic.GetEmployees().Result;
            Assert.Equal(2, getEmployees.Count);
        }

        [Fact]
        public void EmployeeIfExist()
        {
            var getEmployee = employeeLogic.GetEmployeeById(3).Result;
            Assert.Null(getEmployee);
        }

        [Fact]
        public void CalculateAnnualSalary()
        {
            var getEmployee = employeeLogic.GetEmployeeById(1).Result;
            Assert.Equal(140000, getEmployee.AnnualSalary());
        }
    }
}