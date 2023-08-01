using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Models.Employees
{
    public class EmployeeResponse
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int employee_id { get; set; }
        [Required]
        [MinLength(4)]
        public string employee_name { get; set; }
        [Required]
        [MinLength(4)]
        public string lastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string email { get; set; }
        [Required]
        [MinLength(15)]
        public string personalAddress { get; set; }
        [Required]
        [Phone]
        public string phone { get; set; }
        [Required]
        public DateTime workingStartingDate { get; set; }
        [Required]
        public float startingSalary { get; set; }
        [Required]
        public float currentSalary { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}
