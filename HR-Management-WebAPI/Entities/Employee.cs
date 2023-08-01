using HR_Management_WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [MinLength(4)]
        [DefaultValue("Alain")]
        public string employee_name { get; set; }
        [Required]
        [MinLength(4)]
        [DefaultValue("Jorge Acuña")]
        public string lastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string email { get; set; }
        [Required]
        [MinLength(15)]
        [DefaultValue("Lorem ipsum est magnam numquam rem excepturi.")]
        public string personalAddress { get; set; }
        [Required]
        [Phone]
        [MinLength(12)]
        [DefaultValue("012-345-6789")]
        public string phone { get; set; }
        [Required]
        public DateTime workingStartingDate { get; set; }
        [Required]
        [DefaultValue("256.75")]
        public float startingSalary { get; set; }

        //public List<Role> Roles { get; set; } = new List<Role>();
        [Required]
        [DefaultValue("[1]")]
        //[RegularExpression(@"^[1-3](,[1-3])*$")]
        //[RegularExpression(@"^(?:\d+|\d{1,3}(?:,\d{3})+)$")]
        //[RegularExpression(@"^(?:\d+|\d{1,3}(?:,\d{3})+)$")]
        public List<int> Roles { get; set; } = new List<int>();
    }
}
