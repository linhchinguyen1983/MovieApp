namespace MovieApi.Model.DomainModel
{
    public class MovieGenre
    {
        public Guid MoviesId { get; set; }
        public Guid GenresId { get; set; }
        public Movies Moives { get; set; }
        public Genres Genres { get; set; } 
    }
}
