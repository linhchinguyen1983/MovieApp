using Microsoft.AspNetCore.Mvc;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;

namespace MovieApi.Repository
{
    public interface IGenreRepository
    {
        // get all genres in database
        public Task<List<Genres>> GetAllGenreAsync(int? status =null);
        // Insert genre to database
        public Task<Genres> AddGenreAsync(Genres genre);
        // get genres by id
        public Task<Genres> GetById(Guid id);
        // hide genres
        public Task<bool> DeleteGenreAsync(Guid id);
        // update Genre
        public Task<Genres>? UpdateGenreAsync(Guid id, Genres genre);
    }
}
