using HR_Management_WebAPI.Resources;

namespace HR_Management_WebAPI.Entities
{
    public class Role
    {
        [Display(ResourceType = typeof(DisplayNameResource), Name = "Rol_Id")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int role_id { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Rol_Name")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [MinLength(4, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MinLengthError")]
        public string rol_name { get; set; }
    }
}