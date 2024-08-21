using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Model.DomainModel;

namespace MovieApi.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public CommentRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public async Task<Comment?> UpdateAsync(Guid id ,Comment comment)
        {
            var updatedComment = await _movieDbContext.Comments.FindAsync(id);
            if(updatedComment != null)
            {
                updatedComment.Content = comment.Content;
                updatedComment.LastUpdate = DateTime.Now;
                try
                {
                    await _movieDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return updatedComment;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var comment = await _movieDbContext.Comments.FindAsync(id);
            if (comment != null) 
            {
                _movieDbContext.Comments.Remove(comment);   
                await _movieDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Comment>> GetAllCommentAsync(Guid movieId)
        {
            var comments = await (from c in _movieDbContext.Comments 
                                  where c.MoviesId == movieId
                                  select
                                  new Comment
                                  {
                                      Id = c.Id,
                                      CreatedDate = c.CreatedDate,
                                      MoviesId = c.MoviesId,
                                      Content = c.Content,
                                      LastUpdate = c.LastUpdate,
                                  }).ToListAsync();
            return comments;
        }

        public async Task<Comment?> GetCommentAsync(Guid movieId , Guid commentId)
        {
            var comment = await (from c in _movieDbContext.Comments
                                 where c.MoviesId == movieId && c.Id == commentId
                                 select new Comment()
                                 {
                                     Id = c.Id,
                                     CreatedDate = c.CreatedDate,
                                     MoviesId = c.MoviesId,
                                     Content = c.Content,
                                 }).FirstOrDefaultAsync();
            return comment;
        }

        public async Task<Comment?> AddCommentAsync(Comment comment)
        {
            try
            {
                var newComment = await _movieDbContext.AddAsync(comment);
                await _movieDbContext.SaveChangesAsync();
                return newComment.Entity;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
