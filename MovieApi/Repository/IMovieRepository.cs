using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Repository
{
    public interface IMovieRepository
    {
        /// <summary>
        /// save movie's data into database
        /// </summary>
        /// <param name="movies">movie object</param>
        /// <returns>return movie if save data success, null if failed</returns>
        public Task<Movies> CreateMovieAsync(Movies movies);

        /// <summary>
        /// Get movie's data by id
        /// </summary>
        /// <param name="id">id of movie</param>
        /// <returns>return movie data if id exist in database , null if not exist</returns>
        public Task<Movies> GetMovieAsync(Guid id);

        /// <summary>
        /// get all movies in database
        /// </summary>
        /// <returns>a list of movie</returns>
        public Task<List<Movies>> GetAllMoviesAsync();

        /// <summary>
        /// hide movie by change status to 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns>if delete successfully return true , else return false </returns>
        public Task<bool> DeleteMovieAsync(Guid id);

        /// <summary>
        /// update movie in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateMovieDto"></param>
        /// <returns></returns>
        public Task<Movies> UpdateMovieAsync(Guid id, UpdateMovieDto updateMovieDto);
    }
}
