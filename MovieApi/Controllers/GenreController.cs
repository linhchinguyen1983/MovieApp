using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api/genre")]
    [ApiController]
    
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreController(IGenreRepository genreRepository, IMapper mapper) {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var genres = await _genreRepository.GetAllGenreAsync();
            return Ok(_mapper.Map<Genres>(genres));
        }
        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] AddGenreRequestDto addGenreRequestDto) {
            var genre = _mapper.Map<Genres>(addGenreRequestDto);
            var newGenre = await _genreRepository.AddGenreAsync(genre);
            return Ok(_mapper.Map<GenreDto>(newGenre));
        
        }
    }
}
