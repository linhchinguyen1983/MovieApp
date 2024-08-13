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

        public async Task<bool> UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre == null) 
            {
                Console.WriteLine($"Genre with Id {id} not found.");
                return false;
            }
            else
            {
                genre.Status = updateGenreDto.Status;
                genre.Name = updateGenreDto.Name;
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Genres>> GetAllGenreAsync()
        {
            var genres = await _dbContext.Genres.ToListAsync();
            return genres;
        }

        public async Task<Genres> GetById(Guid id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            return genre;
        }


    }
}
