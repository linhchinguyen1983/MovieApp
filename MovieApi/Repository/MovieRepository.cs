using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext) 
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<Movies> CreateMovieAsync(Movies movie)
        {
            try
            {
                if (movie != null)
                {
                    var newMovie = await _movieDbContext.AddAsync(movie);
                    await _movieDbContext.SaveChangesAsync();
                    return newMovie.Entity;
                }
                return null;
        
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var deletedMovie = await _movieDbContext.Movies.FindAsync(id);
            if (deletedMovie != null) { return false; }
            else deletedMovie.Status = 0;
            await _movieDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Movies>> GetAllMoviesAsync()
        {
            var listMovie = await _movieDbContext.Movies.ToListAsync();
            return listMovie;
        }

        public async Task<Movies?> GetMovieAsync(Guid id)
        {
            var movie = await _movieDbContext.Movies.FindAsync(id);
            return movie;
        }

        public async Task<Movies> UpdateMovieAsync(Guid id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieDbContext.Movies.FindAsync(id);
            if (movie == null) { return null; }
            else
            {
                movie.Title = updateMovieDto.Title;
                movie.Description = updateMovieDto.Description;
                movie.AgeRating = updateMovieDto.AgeRating;
                movie.Status = updateMovieDto.Status;
                movie.Poster = updateMovieDto.Poster;

                await _movieDbContext.SaveChangesAsync();
                return movie;
            }

        }
    }
}
