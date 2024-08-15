using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class UpdateNewsDto
    {
        [Required(ErrorMessage = "News's image must not be empty")]
        public string Image { get; set; }
        [Required]
        public int Status { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
