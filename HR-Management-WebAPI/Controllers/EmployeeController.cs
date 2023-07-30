using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeesRepo;

        public EmployeeController(IEmployeeRepository repo)
        {
            _employeesRepo = repo;
        }

        /// <summary>
        /// Api Get method to get list of employees.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeesRepo.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to delete an existing employee.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{employee_id}")]
        public async Task<IActionResult> DeleteEmployee(int employee_id)
        {
            try
            {
                var roleFound = await _employeesRepo.GetEmployeeById(employee_id);
                if (roleFound == null)
                    return NotFound("No employee found matching the supplied identifier.");

                CustomResponse model = await _employeesRepo.DeleteEmployee(employee_id);
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
