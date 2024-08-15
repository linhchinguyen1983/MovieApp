using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Middlewares;
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
            var genre = await _genreRepository.GetById(id);
            return Ok(_mapper.Map<GenreDto>(genre));
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int?status)
        {
            var genres = await _genreRepository.GetAllGenreAsync(status);
            return Ok(_mapper.Map<List<GenreDto>>(genres));
        }
        [HttpPost]
        public async Task<IActionResult> AddGenre([FromBody] AddGenreRequestDto addGenreRequestDto) {
            var genre = _mapper.Map<Genres>(addGenreRequestDto);
            var newGenre = await _genreRepository.AddGenreAsync(genre);
            return Ok(_mapper.Map<GenreDto>(newGenre));

        }
        // CHUA SET QUYEN DE THUC HIEN AN GENRE
        [HttpDelete]
        // [SessionRequirement("writer")]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] Guid id)
        {
            var isDelete = await _genreRepository.DeleteGenreAsync(id);
            if (isDelete) return Ok("Delete Success!");
            else return BadRequest("Delete failed!");

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGenre([FromBody]UpdateGenreDto updateGenreDto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = _mapper.Map<Genres>(updateGenreDto);
            var updatedGenre = await _genreRepository.UpdateGenreAsync(id, genre);
            if (updatedGenre == null) { return StatusCode(500); }
            return Ok(_mapper.Map<GenreDto>(updatedGenre));
        }
    }
}
