using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MovieApi.Model.Dto
{
    public class UpdateCommentDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required(ErrorMessage = "Movie id must not null")]
        public DateTime? LastUpdate { get; set; } = DateTime.Now;
        public Guid MoviesId { get; set; }
    }
}
