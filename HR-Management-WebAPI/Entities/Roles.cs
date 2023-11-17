namespace HR_Management_WebAPI.Entities
{
    public class Role
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int role_id { get; set; }

        [Required]
        [MinLength(4)]
        public string rol_name { get; set; }
    }
}