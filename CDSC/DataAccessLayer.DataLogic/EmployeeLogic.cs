using DataAccessLayer.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAccessLayer.DataLogic
{
    public class EmployeeLogic
    {
        public Task<List<EmployeeDTO>> GetEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees")
            };

            var responseTask = client.GetAsync("employees");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(readTask.Result);
            }
            return Task.FromResult(employees);
        }

        public Task<EmployeeDTO> GetEmployeeById(int id)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees")
            };

            var responseTask = client.GetAsync("employees");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(readTask.Result);
            }

            EmployeeDTO employeeDTO = employees.Find(employee => employee.Id == id);
            return Task.FromResult(employeeDTO);
        }
    }
}