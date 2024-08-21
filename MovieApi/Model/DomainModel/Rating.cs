using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Model.DomainModel
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Star { get; set; }

        [Required]
        public Guid MoviesId { get; set; } // Khóa ngoại cho Movies

        public Guid UserId { get; set; }

        // Thuộc tính điều hướng
        public Movies Movies { get; set; }
        public User User { get; set; }
    }
}
