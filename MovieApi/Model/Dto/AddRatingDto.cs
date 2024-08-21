namespace MovieApi.Model.Dto
{
    public class AddRatingDto
    {
        public int Star { get; set; }
        public Guid MoviesId { get; set; }
        public Guid UserId { get; set; }
    }
}
