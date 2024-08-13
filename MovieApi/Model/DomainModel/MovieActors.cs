namespace MovieApi.Model.DomainModel
{
    public class MovieActors
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        public Movies Movies { get; set; }
        public Actors Actors { get; set; }
    }
}
