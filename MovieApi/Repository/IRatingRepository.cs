using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public interface IRatingRepository
    {
        public Task<Rating>? AddRatingAsync(Rating rating);
        public Task<double> AvgRating(Guid movieId);
    }
}
