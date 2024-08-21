using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class AddRatingDto
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Star { get; set; }

        public Guid MoviesId { get; set; }

        public Guid UserId { get; set; }
    }

}
