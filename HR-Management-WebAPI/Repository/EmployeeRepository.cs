namespace HR_Management_WebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> AddEmployeeSalaryIncrease(int employee_id, int pending_months)
        {
            try
            {
                var query = "Usp_HR_AddEmployeeSalaryIncrease";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_id", employee_id, DbType.Int32);
                    parameters.Add("pending_months", pending_months, DbType.Int32);
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

        public async Task<CustomResponse> CreateEmployee(Employee employee)
        {
            try
            {
                var query = "Usp_HR_AddEmployee";
                var roles = String.Join(",", employee.Roles);
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_id", employee.employee_id, DbType.Int32);
                    parameters.Add("employee_name", employee.employee_name.ToString(), DbType.String);
                    parameters.Add("lastName", employee.lastName.ToString(), DbType.String);
                    parameters.Add("email", employee.email.ToString(), DbType.String);
                    parameters.Add("personalAddress", employee.personalAddress.ToString(), DbType.String);
                    parameters.Add("phone", employee.phone.ToString(), DbType.String);
                    parameters.Add("workingStartingDate", employee.workingStartingDate.ToString(), DbType.String);
                    parameters.Add("startingSalary", employee.startingSalary.ToString(), DbType.String);
                    parameters.Add("roles", roles, DbType.String);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("prp_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");
                    var id = parameters.Get<int?>("prp_id");

                    var createdCompany = new Employee
                    {
                        employee_id = employee.employee_id,
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

        public async Task<int> GetEmployeeLatestRevisionDate(int employee_id)
        {
            try
            {
                var query = "Usp_HR_SelEmployeeLatestRevisionDate";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("employee_id", employee_id, DbType.Int32);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("@salary_review_proceeds", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var LatestRevisionDate = parameters.Get<Int32>("salary_review_proceeds");

                    return LatestRevisionDate;
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<List<EmployeeResponse>> GetEmployees()
        {
            var procedure = "Usp_HR_SelEmployee";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return (await connection.QueryAsync<EmployeeResponse>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<List<HistoricalSalaries>> SelEmployeeHistoricalSalaries(int employee_id)
        {
            var procedure = "Usp_HR_SelHistoricalSalaries";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("employee_id", employee_id, DbType.Int32);
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return (await connection.QueryAsync<HistoricalSalaries>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<CustomResponse> UpdateEmployee(int employee_id, Employee employee)
        {
            try
            {
                var query = "Usp_HR_UpdEmployee";
                var roles = String.Join(",", employee.Roles);
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
                    parameters.Add("roles", roles, DbType.String);
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