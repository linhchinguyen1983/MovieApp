using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api/new")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRpository;
        private readonly IMapper _mapper;
        public NewsController (INewsRepository newsRespository, IMapper mapper)
        {
            _newsRpository = newsRespository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int?status)
        {
            var news = await _newsRpository.GetAllNewsAsync(status);
            return Ok(_mapper.Map<List<NewsDto>>(news));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var news = await _newsRpository.GetById(id);
            return Ok(_mapper.Map <NewsDto> (news));
        }
        [HttpPost]
        public async Task<IActionResult> AddNews([FromBody] NewsRequestDto newsRequestDto)
        {
            var news = _mapper.Map<News>(newsRequestDto);
            var newNews = await _newsRpository.AddNewsAsync(news);
            return Ok(_mapper.Map<NewsDto>(newNews));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateNews([FromRoute] Guid id, [FromBody] UpdateNewsDto updateNewsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var news = _mapper.Map<News>(updateNewsDto);
            var updateNews = await _newsRpository.UpdateNewsAsync(id, news);
            if (updateNews == null) { return StatusCode(500); }
            return Ok(_mapper.Map<NewsDto> (updateNews));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            var isDelete = await _newsRpository.DeleteNewsAsync(id);
            if (isDelete) return Ok("Delete Success");
            else return BadRequest("Delete Failed");
        }
    }
}
