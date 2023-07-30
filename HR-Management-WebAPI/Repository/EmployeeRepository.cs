using Dapper;
using HR_Management_WebAPI.Context;
using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using HR_Management_WebAPI.Helpers;
using HR_Management_WebAPI.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
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

        public async Task<List<Employee>> GetEmployees()
        {
            var procedure = "Usp_HR_SelEmployee";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return (await connection.QueryAsync<Employee>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public Task<CustomResponse> UpdateRole(int role_id, CreateRequest role)
        {
            throw new NotImplementedException();
        }
    }
}
