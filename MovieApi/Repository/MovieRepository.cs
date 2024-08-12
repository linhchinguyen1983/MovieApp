using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public Task<Movies> CreateMovieAsync(Movies movies)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movies>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Movies> GetMovieAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
