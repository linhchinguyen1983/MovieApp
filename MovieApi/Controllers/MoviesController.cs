using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Middlewares;
using MovieApi.Model.DomainModel;
using MovieApi.Model.Dto;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository; 
        }

        [HttpGet]
        [Route("{id}")]
        [SessionRequirement("reader", "writer")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            //mapping data to dto and send it to client
            return Ok(_mapper.Map<MovieDto>(movie));
        }

        [HttpGet]
        [SessionRequirement("reader", "writer")]
        public async Task<IActionResult> GetAllMovie()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            //mapping data to dto and send it to client
            return Ok(_mapper.Map<List<MovieDto>>(movies));
        }
        [HttpPost]
        [SessionRequirement("writer")]
        public async Task<IActionResult> UploadMovie([FromBody] UploadMovieRequestDto uploadMovieRequestDto)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            // mapping dto to movie object
            Movies movie = _mapper.Map<Movies>(uploadMovieRequestDto);
            // save movie data to database
            var newMovie = await _movieRepository.CreateMovieAsync(movie);
            if(newMovie != null)
            {
                return StatusCode(500);
            }
            return Ok(_mapper.Map<MovieDto>(newMovie));
        }

        [HttpDelete]
        [SessionRequirement("writer")]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
        {
            var isDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (isDeleted) return Ok("Delete success!");
            else return BadRequest("Delete failed!");
        }

        
    }
}
