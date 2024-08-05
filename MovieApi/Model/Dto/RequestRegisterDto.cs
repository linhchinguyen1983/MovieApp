using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class RequestRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "User's roles are required!")]
        public List<string> Roles { get; set; }
        
    }
}
