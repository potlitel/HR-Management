using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Models.Employees
{
    public class CreateRequest
    {
        [Required]
        public string employee_name { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string personalAddress { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public DateTime workingStartingDate { get; set; }
        [Required]
        public float startingSalary { get; set; }
    }
}
