using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model.Dto
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AgeRating { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public byte[] Poster { get; set; }
    }
}
