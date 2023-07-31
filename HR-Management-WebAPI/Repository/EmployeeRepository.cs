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
        public async Task<CustomResponse> CreateEmployee(CreateEmployeeRequest employee)
        {
            try
            {
                var query = "Usp_HR_AddEmployee";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_name", employee.employee_name.ToString(), DbType.String);
                    parameters.Add("lastName", employee.lastName.ToString(), DbType.String);
                    parameters.Add("email", employee.email.ToString(), DbType.String);
                    parameters.Add("personalAddress", employee.personalAddress.ToString(), DbType.String);
                    parameters.Add("phone", employee.phone.ToString(), DbType.String);
                    parameters.Add("workingStartingDate", employee.workingStartingDate.ToString(), DbType.String);
                    parameters.Add("startingSalary", employee.startingSalary.ToString(), DbType.String);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("prp_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");
                    var id = parameters.Get<int?>("prp_id");


                    var createdCompany = new Employee
                    {
                        employee_id = (int)id,
                        employee_name = employee.employee_name,
                        lastName = employee.lastName,
                        email = employee.email,
                        personalAddress = employee.personalAddress,
                        phone = employee.phone,
                        workingStartingDate = employee.workingStartingDate,
                        startingSalary = employee.startingSalary,
                    };

                    return new CustomResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = message,
                        Data = createdCompany
                    };
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
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

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            var procedure = "Usp_HR_SelByEmailEmployee";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("employee_email", email.ToString(), DbType.String);
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return await connection.QuerySingleOrDefaultAsync<Employee>(procedure, parameters, null, commandType: CommandType.StoredProcedure);
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

        public async Task<CustomResponse> UpdateEmployee(int employee_id, CreateEmployeeRequest employee)
        {
            try
            {
                var query = "Usp_HR_UpdEmployee";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_id", employee_id, DbType.Int32);
                    parameters.Add("employee_name", employee.employee_name.ToString(), DbType.String);
                    parameters.Add("lastName", employee.lastName.ToString(), DbType.String);
                    parameters.Add("email", employee.email.ToString(), DbType.String);
                    parameters.Add("personalAddress", employee.personalAddress.ToString(), DbType.String);
                    parameters.Add("phone", employee.phone.ToString(), DbType.String);
                    parameters.Add("workingStartingDate", employee.workingStartingDate.ToString(), DbType.String);
                    parameters.Add("startingSalary", employee.startingSalary.ToString(), DbType.String);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");


                    var createdCompany = new Employee
                    {
                        employee_id = employee_id,
                        employee_name = employee.employee_name,
                        lastName = employee.lastName,
                        email = employee.email,
                        personalAddress = employee.personalAddress,
                        phone = employee.phone,
                        workingStartingDate = employee.workingStartingDate,
                        startingSalary = employee.startingSalary,
                    };

                    return new CustomResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = message,
                        Data = createdCompany
                    };
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }
    }
}
