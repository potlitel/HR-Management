using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Models.Employees
{
    public class CreateEmployeeRequest
    {
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
        //According to https://www.abstractapi.com/guides/how-to-validate-phone-numbers-in-asp-nets
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$.")]
        //[RegularExpression(@"^(\(?\s*\d{3}\s*[\)\-\.]?\s*)?[2-9]\d{3}\s*[\-\.]\s*\d{4}$")]
        public string phone { get; set; }
        [Required]
        public DateTime workingStartingDate { get; set; }
        [Required]
        public float startingSalary { get; set; }
    }
}
