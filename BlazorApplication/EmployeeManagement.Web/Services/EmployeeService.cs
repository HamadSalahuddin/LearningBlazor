using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var employeeResponse = await httpClient.GetAsync("api/employees");
            employeeResponse.EnsureSuccessStatusCode();

            var responseString = await employeeResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseString);
        }
    }
}
