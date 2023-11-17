namespace HR_Management_WebAPI.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _context;

        public RoleRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreateRole(Role role)
        {
            try
            {
                var query = "Usp_HR_AddRol";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("role_id", role.role_id, DbType.Int32);
                    parameters.Add("rol_name", role.rol_name.ToString(), DbType.String);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    parameters.Add("prp_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");
                    var id = parameters.Get<int?>("prp_id");

                    var createdCompany = new Role
                    {
                        role_id = (int)id,
                        rol_name = role.rol_name
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

        public async Task<CustomResponse> DeleteRole(int rol_id)
        {
            try
            {
                var query = "Usp_HR_DelRol";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("role_id", rol_id, DbType.Int32);
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

        public async Task<Role> GetRoleById(int role_id)
        {
            var procedure = "Usp_HR_SelByIdRol";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("role_id", role_id, DbType.Int32);
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return await connection.QuerySingleOrDefaultAsync<Role>(procedure, parameters, null, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Role> GetRoleByName(string name)
        {
            var procedure = "Usp_HR_SelByNameRol";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("rol_name", name.ToString(), DbType.String);
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return await connection.QuerySingleOrDefaultAsync<Role>(procedure, parameters, null, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            var procedure = "Usp_HR_SelRol";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                return (await connection.QueryAsync<Role>(procedure, parameters, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<CustomResponse> UpdateRole(int role_id, Role role)
        {
            try
            {
                var query = "Usp_HR_UpdRol";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("role_id", role_id, DbType.Int32);
                    parameters.Add("rol_name", role.rol_name.ToString(), DbType.String);
                    parameters.Add("prp_mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);

                    await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);

                    var message = parameters.Get<string>("prp_mensaje");

                    var createdCompany = new Role
                    {
                        role_id = role_id,
                        rol_name = role.rol_name
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