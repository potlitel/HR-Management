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
        public string phone { get; set; }

        [Required]
        public DateTime workingStartingDate { get; set; }

        [Required]
        public float startingSalary { get; set; }
    }
}