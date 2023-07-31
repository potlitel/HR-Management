using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Entities
{
    public class Employee
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int employee_id { get; set; }
        [Required]
        public string employee_name { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string email { get; set; }
        [Required]
        public string personalAddress { get; set; }
        [Required]
        [Phone]
        public string phone { get; set; }
        [Required]
        public DateTime workingStartingDate { get; set; }
        [Required]
        public float startingSalary { get; set; }

        //public List<Role> Roles { get; set; } = new List<Role>();
        [Required]
        //[RegularExpression(@"^[1-3](,[1-3])*$")]
        public List<int> Roles { get; set; } = new List<int>();
    }
}
