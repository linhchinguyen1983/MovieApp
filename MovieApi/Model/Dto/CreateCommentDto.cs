using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content { get; set; }
        public DateTime CreateDate { get ; set; }
        [Required]
        public Guid MoviesId { get; set; }
    }
}
