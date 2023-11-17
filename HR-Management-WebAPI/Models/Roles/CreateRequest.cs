namespace HR_Management_WebAPI.Models.Roles
{
    public class CreateRequest
    {
        [Required]
        public string rol_name { get; set; }
    }
}