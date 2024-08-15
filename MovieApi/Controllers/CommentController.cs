using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentController(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        [HttpGet]
        [Route("{movieId}/comment")]
        public async Task<IActionResult> GetAllComment([FromRoute] Guid movieId)
        {
            var comments = await _commentRepository.GetAllCommentAsync(movieId);
            return Ok(_mapper.Map<CommentDto>(comments));
        }

        [HttpGet]
        [Route("{movieId}/comment/{id}")]
        public async Task<IActionResult> GetComment([FromRoute] Guid movieId, [FromRoute] Guid id)
        {
            var comment = await _commentRepository.GetCommentAsync(movieId, id);
            if(comment == null) return NotFound(new {result = "your resource doesn't found!"});
            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> CreateComment([FromBody] PostCommentDto postCommentDto)
        {
            var comment = _mapper.Map<CommentDto>(postCommentDto);
            return Ok(comment);
        }

        [HttpDelete]
        [Route("comment/{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            var isDeleted = await _commentRepository.DeleteAsync(id);
            return Ok(new { Status = isDeleted });
        }

        [HttpPut]
        [Route("comment/{id}")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateCommentDto, [FromRoute] Guid id)
        {
            var updatedComment = _mapper.Map<Comment>(updateCommentDto);
            var newComment = await _commentRepository.UpdateAsync(id , updatedComment);
            if (updatedComment == null) return BadRequest("Comment does not exist in database!");
            return Ok(_mapper.Map<CommentDto>(updatedComment));
        }
    }
}
