using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class UpdateMovieDto
    {
        [Required(ErrorMessage = "Movie's tilte must not be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie's description must not be empty")]
        public string? Description { get; set; }
        public int AgeRating { get; set; }
        [Required]
        public int Status { get; set; }
        [Required(ErrorMessage = "Poster must not be null")]
        public string Poster { get; set; }
        [Required(ErrorMessage = "Expected episode must not be null")]
        public int ExpectedEpisode { get; set; }
    }
}
