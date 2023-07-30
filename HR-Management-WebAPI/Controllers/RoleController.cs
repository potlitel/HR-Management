using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using HR_Management_WebAPI.Helpers;
using HR_Management_WebAPI.Models.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _rolesRepo;

        public RoleController(IRoleRepository repo)
        {
            _rolesRepo = repo;
        }

        /// <summary>
        /// Api Get method to get list of roles.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _rolesRepo.GetRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to create a new role.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRol(CreateRequest role)
        {
            try
            {
                if (await _rolesRepo.GetRoleByName(role.rol_name!) != null)
                    throw new ApplicationException("Role with the name '" + role.rol_name + "' already exists.");
                CustomResponse model = await _rolesRepo.CreateRole(role);
                return Ok(new { message = model.Message, data = model.Data });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to update an existing role.
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{role_id}")]
        public async Task<IActionResult> UpdateRol(int role_id, CreateRequest role)
        {
            try
            {
                var roleFound = await _rolesRepo.GetRoleById(role_id);
                if (roleFound == null)
                    return NotFound("No role found matching the supplied identifier.");
                CustomResponse model = await _rolesRepo.UpdateRole(role_id, role);
                return Ok(new { message = model.Message, data = model.Data });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to delete an existing role.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{role_id}")]
        public async Task<IActionResult> DeleteRol(int role_id)
        {
            try
            {
                var roleFound = await _rolesRepo.GetRoleById(role_id);
                if (roleFound == null)
                    return NotFound("No role found matching the supplied identifier.");

                CustomResponse model = await _rolesRepo.DeleteRole(role_id);
                return Ok(new { message = model.Message });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
