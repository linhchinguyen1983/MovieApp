using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace MovieApi.Model.Dto
{
    public class UploadMovieRequestDto
    {
        [Required(ErrorMessage = "Movie's tilte must not be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie's description must not be empty")]
        public string Description { get; set; }
        public int? AgeRating { get; set; }
        public int Status {get; set; }
        [Required(ErrorMessage = "Movie's url must not be null")]
        public string Url { get; set; }
        [Required(ErrorMessage = "Poster must not be null")]
        //using base64 encode to save image data
        public string Poster { get; set; }
    }
}
