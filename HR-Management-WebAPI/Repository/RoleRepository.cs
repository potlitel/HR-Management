using Dapper;
using HR_Management_WebAPI.Context;
using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _context;

        public RoleRepository(DapperContext context)
        {
            _context = context;
        }

        public Task<int> CreateRole(Role role)
        {
            var parameters = new DynamicParameters();
            parameters.Add("rol_name", role.rol_name, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                SqlTransaction sqltrans = (SqlTransaction)connection.BeginTransaction();
                var result = connection.Execute("Usp_HR_AddRol", parameters, sqltrans, 0, CommandType.StoredProcedure);
                if (result > 0)
                {
                    sqltrans.Commit();
                }
                else
                {
                    sqltrans.Rollback();
                }
                return Task.FromResult(result);
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
    }
}
