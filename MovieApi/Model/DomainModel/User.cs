using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.DomainModel
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
    }

}
