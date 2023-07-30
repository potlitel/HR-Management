using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
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

        [HttpPost]
        public async Task<IActionResult> CreateCompany(Role company)
        {
            try
            {
                var createdCompany = await _rolesRepo.CreateRole(company);
                return CreatedAtRoute("CompanyById", new { id = createdCompany }, createdCompany);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
