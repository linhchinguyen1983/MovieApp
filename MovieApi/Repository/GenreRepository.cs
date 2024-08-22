using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

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

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            var deleteGenre = await _dbContext.Genres.FindAsync(id);
            if (deleteGenre == null)
            {
                Console.WriteLine($"Genre with Id {id} not found.");
                return false;
            }

            deleteGenre.Status = 0;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Genres>? UpdateGenreAsync(Guid id, Genres genre)
        {
            try
            {
                var updateGenre = await _dbContext.Genres.FindAsync(id);
                updateGenre.Status = genre.Status;
                updateGenre.Name = genre.Name;
                await _dbContext.SaveChangesAsync();
                return updateGenre;
            }
            catch (Exception ex)
            {
                return null;
            }
            
            
        }

        public async Task<List<Genres>> GetAllGenreAsync(int? status = null)
        {
            var query = _dbContext.Genres.AsQueryable();
            if (status.HasValue)
            {
                return await _dbContext.Genres.Where(g => g.Status == status.Value).ToListAsync();
            }
            return await query.ToListAsync();
           /* var genres = await _dbContext.Genres.Where(g => g.Status == 1).ToListAsync();
            return genres;*/
        }

        public async Task<Genres> GetById(Guid id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre == null || genre.Status == 0) return null;
            return genre;
        }


    }
}
