using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Management_WebAPI.Models.Roles
{
    public class CreateRequest
    {
        [Required]
        public string rol_name { get; set; }
    }
}
