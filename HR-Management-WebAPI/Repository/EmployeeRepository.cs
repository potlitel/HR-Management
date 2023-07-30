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
using System.Net;
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
        public Task<CustomResponse> CreateEmployee(CreateRequest role)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponse> DeleteEmployee(int employee_id)
        {
            try
            {
                var query = "Usp_HR_DelEmployee";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_id", employee_id, DbType.Int32);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");

                    return (new CustomResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = message,
                    });
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Employee> GetEmployeeById(int employee_id)
        {
            var procedure = "Usp_HR_SelByIdEmployee";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("employee_id", employee_id, DbType.Int32);
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return await connection.QuerySingleOrDefaultAsync<Employee>(procedure, parameters, null, commandType: CommandType.StoredProcedure);
            }
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

        public Task<CustomResponse> UpdateEmployee(int role_id, CreateRequest role)
        {
            throw new NotImplementedException();
        }
    }
}
