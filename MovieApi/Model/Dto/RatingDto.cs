using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public int Star { get; set; }
    }
}
