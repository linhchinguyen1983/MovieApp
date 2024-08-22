using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Repository
{
    public class NewsRespository : INewsRepository
    {
        public readonly MovieDbContext _dbContext;
        public NewsRespository(MovieDbContext movieDbContext)
        {
            _dbContext = movieDbContext;
        }
        public async Task<News> AddNewsAsync(News news)
        {
            try
            {
                var newNews = await _dbContext.AddAsync(news);
                await _dbContext.SaveChangesAsync();
                return newNews.Entity;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteNewsAsync(Guid id)
        {
            var deleteNews = await _dbContext.News.FindAsync(id);
            if (deleteNews == null) 
            {
                Console.WriteLine($"news with Id {id} not found.");
                return false;
            }
            deleteNews.Status = 0;
            await _dbContext.SaveChangesAsync();
            return true;
            
        }

        public async Task<List<News>> GetAllNewsAsync(int? status =null)
        {
            var query= _dbContext.News.AsQueryable();
            if (status.HasValue)
            {
                return await _dbContext.News.Where(n =>n.Status == status.Value).ToListAsync();
            }
            return await query.ToListAsync();
            /*var news = await _dbContext.News.Where(n=> n.Status ==1).ToListAsync();
            return news;*/
        }

        public async Task<News> GetById(Guid id)
        {
            var news = await _dbContext.News.FindAsync(id);
            return news;
        }

        public async Task<News>? UpdateNewsAsync(Guid id, News news)
        {
            try
            {
                var updateNews = await _dbContext.News.FindAsync(id);
                updateNews.Status = news.Status;
                updateNews.Image = news.Image;
                updateNews.UpdateAt = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return updateNews;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
