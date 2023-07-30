using Dapper;
using HR_Management_WebAPI.Context;
using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using HR_Management_WebAPI.Helpers;
using HR_Management_WebAPI.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

        public async Task<CustomResponse> CreateRole(CreateRequest role)
        {
            try
            {
                var query = "Usp_HR_AddRol";
                using (var connection = _context.CreateConnection())
                {
                    var parameters = new DynamicParameters();
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

                    return (new CustomResponse
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = message,
                        Data = createdCompany
                    });
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
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
