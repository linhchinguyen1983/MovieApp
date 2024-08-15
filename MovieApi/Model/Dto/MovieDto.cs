using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int AgeRating { get; set; }
        public int Status { get; set; } = 1;
        public string Poster { get; set; }
        public int ExpectedEpisode { get; set; }
        public bool Type { get; set; }
    }
}
