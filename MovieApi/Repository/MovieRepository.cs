using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public Task<Movies> CreateMovie(Movies movies)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movies>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movies> GetMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
