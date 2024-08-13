namespace MovieApi.Model.DomainModel
{
    public class MovieActors
    {
        public Guid MoviesId { get; set; }
        public Guid ActorsId { get; set; }

        //Navigate propperties
        public Movies Movies { get; set; }
        public Actors Actors { get; set; }
    }
}
