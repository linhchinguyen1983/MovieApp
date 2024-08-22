using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Repository
{
    public interface INewsRepository
    {
        public Task<List<News>> GetAllNewsAsync(int ?status = null);
        public Task<News> GetById(Guid id);
        public Task<News> AddNewsAsync(News news);
        public Task<News>? UpdateNewsAsync(Guid id, News news);
        public Task<bool> DeleteNewsAsync(Guid id);
    }
}
