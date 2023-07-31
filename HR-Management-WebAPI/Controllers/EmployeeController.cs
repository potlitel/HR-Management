using HR_Management_WebAPI.Contracts;
using HR_Management_WebAPI.Entities;
using HR_Management_WebAPI.Helpers;
using HR_Management_WebAPI.Models.Employees;
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
        /// Api Get method to create a new employee.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                if (await _employeesRepo.GetEmployeeById(employee.employee_id!) != null)
                    throw new ApplicationException("Employee with the identifier '" + employee.employee_id + "' already exists.");
                if (await _employeesRepo.GetEmployeeByEmail(employee.email!) != null)
                    throw new ApplicationException("Employee with the email '" + employee.email + "' already exists.");
                CustomResponse model = await _employeesRepo.CreateEmployee(employee);
                return Ok(new { message = model.Message, data = model.Data });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to update an existing employee.
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{employee_id}")]
        public async Task<IActionResult> UpdateEmployee(int employee_id, Employee employee)
        {
            try
            {
                var employeeFound = await _employeesRepo.GetEmployeeById(employee_id);
                if (employeeFound == null)
                    throw new ApplicationException("No employee found matching the supplied identifier");
                var emailChanged = (employeeFound.email.Trim().ToString() != employee.email.Trim().ToString());
                //if (emailChanged && await _employeesRepo.GetEmployeeByEmail(employee.email!) != null)
                if (emailChanged)
                    throw new ApplicationException("Employee with the email '" + employee.email + "' already exists.");

                CustomResponse model = await _employeesRepo.UpdateEmployee(employee_id, employee);
                return Ok(new { message = model.Message, data = model.Data });
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

        /// <summary>
        /// Api Get method to calculate salary increase to an employee.
        /// </summary>
        /// <returns></returns>
        [HttpGet("salaryIncrease/{employee_id}")]
        public async Task<IActionResult> SalaryIncreaseEmployee(int employee_id)
        {
            try
            {
                var roleFound = await _employeesRepo.GetEmployeeById(employee_id);
                if (roleFound == null)
                    return NotFound("No employee found matching the supplied identifier.");
                var latestIncrease = await _employeesRepo.GetEmployeeLatestRevisionDate(employee_id);
                if (latestIncrease < 3)
                    throw new ApplicationException("The 3 months necessary for the salary increase for the worker with identifier '" + employee_id + "' have not elapsed, only '" + latestIncrease + "' months have elapsed since the last salary increase.");
                CustomResponse model = await _employeesRepo.AddEmployeeSalaryIncrease(employee_id, latestIncrease);
                return Ok(new { message = model.Message });
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Api Get method to list historical salaries to an employee.
        /// </summary>
        /// <returns></returns>
        [HttpGet("historicalSalaries/{employee_id}")]
        public async Task<IActionResult> HistoricalSalariesEmployee(int employee_id)
        {
            try
            {
                var roleFound = await _employeesRepo.GetEmployeeById(employee_id);
                if (roleFound == null)
                    return NotFound("No employee found matching the supplied identifier.");
                var historicalSalaries = await _employeesRepo.SelEmployeeHistoricalSalaries(employee_id);
                if (historicalSalaries.Count == 0)
                    throw new ApplicationException("There are no historical salary records for the employee supplied");
                return Ok(historicalSalaries);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
