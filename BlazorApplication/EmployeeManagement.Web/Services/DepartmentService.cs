using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        public readonly HttpClient HttpClient;

        public DepartmentService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
        public async Task<Department> GetDepartment(int id)
        {
            var departmentResponse = await HttpClient.GetAsync($"api/departments/{id}");
            departmentResponse.EnsureSuccessStatusCode();

            var departmentString = await departmentResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Department>(departmentString);

        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var departmentsResponse = await HttpClient.GetAsync($"api/departments");
            departmentsResponse.EnsureSuccessStatusCode();

            var departmentsString = await departmentsResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Department>>(departmentsString);
        }
    }
}
