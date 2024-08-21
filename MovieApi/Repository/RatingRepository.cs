using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Migrations;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MovieDbContext _dbContext;
        public RatingRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Rating>? AddRatingAsync(Rating rating)
        {
            try
            {
                var newRating = await _dbContext.AddAsync(rating);
                await _dbContext.SaveChangesAsync();
                return newRating.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<double> AvgRating(Guid movieId)
        {
            try
            {
                var ratings = from r in _dbContext.Ratings
                              where r.MoviesId == movieId
                              select r.Star;
                var avgRating = await ratings.AverageAsync();
                return avgRating;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
