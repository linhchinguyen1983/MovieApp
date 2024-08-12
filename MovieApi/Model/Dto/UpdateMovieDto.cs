using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class UpdateMovieDto
    {
        [Required(ErrorMessage = "Movie's tilte must not be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie's description must not be empty")]
        public string Description { get; set; }
        public int? AgeRating { get; set; }
        [Required]
        public int Status { get => Status; set => Status = 1; }
        [Required(ErrorMessage = "Movie's url must not be null")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Poster must not be null")]
        //using base64 encode to save image data
        public string Poster { get; set; }
    }
}
