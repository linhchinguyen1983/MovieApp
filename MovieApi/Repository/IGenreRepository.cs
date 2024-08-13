using Microsoft.AspNetCore.Mvc;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public interface IGenreRepository
    {
        public Task<List<Genres>> GetAllGenreAsync();

        public Task<Genres> AddGenreAsync(Genres genre);
    }
}
