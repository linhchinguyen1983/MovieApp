using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;

namespace MovieApi.Repository
{
    public class GenreRepository : IGenreRepository
    {
        public readonly MovieDbContext _dbContext;
        public GenreRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> GetAllGenreAsync()
        {

            throw new NotImplementedException();
        }
    }
}
