using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Entities
{
    public class Employee
    {
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string personalAddress { get; set; }
        public string phone { get; set; }
        public DateTime workingStartingDate { get; set; }

        public float startingSalary { get; set; }

        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
}
