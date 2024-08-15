using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class UpdateGenreDto
    {
        [Required(ErrorMessage = "Genre's name must not be empty")]
        public string Name { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
    