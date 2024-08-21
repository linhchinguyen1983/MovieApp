using Microsoft.AspNetCore.Mvc;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllCommentAsync(Guid movieId);

        public Task<Comment?> GetCommentAsync(Guid movieId, Guid commentId);

        public Task<bool> DeleteAsync(Guid id);

        public Task<Comment?> UpdateAsync(Guid id, Comment comment);
        public Task<Comment?> AddCommentAsync(Comment comment);
    }
}
