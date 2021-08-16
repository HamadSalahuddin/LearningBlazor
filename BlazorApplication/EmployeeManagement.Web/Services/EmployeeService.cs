using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employeesResponse = await httpClient.GetAsync("api/employees");
            employeesResponse.EnsureSuccessStatusCode();

            var responseString = await employeesResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseString);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employeeResponse = await httpClient.GetAsync($"api/employees/{id}");
            employeeResponse.EnsureSuccessStatusCode();

            var responseString = await employeeResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseString);
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var employeeToUpdateJsonString = new StringContent(
                JsonConvert.SerializeObject(updatedEmployee), 
                Encoding.UTF8, 
                "application/json"
            );
            var employeeResponse = await httpClient.PutAsync($"api/employees", employeeToUpdateJsonString);
            employeeResponse.EnsureSuccessStatusCode();

            var responseString = await employeeResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseString);
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var employeeToUpdateJsonString = new StringContent(
                JsonConvert.SerializeObject(newEmployee),
                Encoding.UTF8,
                "application/json"
            );
            var employeeResponse = await httpClient.PostAsync($"api/employees", employeeToUpdateJsonString);
            employeeResponse.EnsureSuccessStatusCode();

            var responseString = await employeeResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(responseString);
        }
    }
}
