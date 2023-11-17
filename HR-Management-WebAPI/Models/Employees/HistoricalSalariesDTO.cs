namespace HR_Management_WebAPI.Models.Employees
{
    public class HistoricalSalariesDTO
    {
        public string employee_id { get; set; }
        public string fullName { get; set; }
        public string startingSalary { get; set; }
        public string salaries_increases { get; set; }
        public string increases_date { get; set; }
        public string increases_period { get; set; }
        public string with_rol { get; set; }
    }
}