using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using HR_Management_WebAPI.Helpers;
using HR_Management_WebAPI.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<CustomResponse> CreateRole(CreateRequest role)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> DeleteRole(int role_id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(int employee_id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> UpdateRole(int role_id, CreateRequest role)
        {
            throw new NotImplementedException();
        }
    }
}
