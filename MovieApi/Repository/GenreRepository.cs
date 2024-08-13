using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class GenreRepository : IGenreRepository
    {
        public readonly MovieDbContext _dbContext;
        public GenreRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genres> AddGenreAsync(Genres genre)
        {
            try
            {
                var newGenre = await _dbContext.AddAsync(genre);
                await _dbContext.SaveChangesAsync();
                return newGenre.Entity;            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        public async Task<List<Genres>> GetAllGenreAsync()
        {
            var genres = await _dbContext.Genres.ToListAsync();
            return genres;
        }


    }
}
