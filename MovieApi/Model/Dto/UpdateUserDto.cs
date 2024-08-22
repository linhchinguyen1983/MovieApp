using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class UpdateUserDto
    { 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
