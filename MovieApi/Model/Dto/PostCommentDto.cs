using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class PostCommentDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Movie id must not null")]
        public Guid MoviesId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
