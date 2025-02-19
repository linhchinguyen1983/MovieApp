﻿using AutoMapper;
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
        //[SessionRequirement("user", "admin" , "vip user")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            //mapping data to dto and send it to client
            return Ok(_mapper.Map<Movies>(movie));
        }

        [HttpGet]
        //[SessionRequirement("user", "admin", "vip user")]
        public async Task<IActionResult> GetAllMovie()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            //mapping data to dto and send it to client
            return Ok(_mapper.Map<List<Movies>>(movies));
        }
        [HttpPost]
        //[SessionRequirement("admin")]
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
            if(newMovie == null)
            {
                return StatusCode(500);
            }
            return Ok(_mapper.Map<Movies>(newMovie));
        }

        [HttpDelete]
        //[SessionRequirement("admin")]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
        {
            var isDeleted = await _movieRepository.DeleteMovieAsync(id);
            if (isDeleted) return Ok("Delete success!");
            else return BadRequest("Delete failed!");
        }

        [HttpPut]
        //[SessionRequirement("admin")]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDto updateMovieDto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var movie = await _movieRepository.UpdateMovieAsync(id, updateMovieDto);
            if(movie != null) return StatusCode(500);
            return Ok(_mapper.Map<Movies>(movie));
        }

        [HttpPost]
        [Route("/upload")]
        public async Task<IActionResult> UploadMovie([FromBody] UploadMovieDto uploadMovieDto)
        {
            return Ok();
        }
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchMovieByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term cannot be empty.");
            }

            var movies = await _movieRepository.SearchMovieByNameAsync(name);

            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found.");
            }

            var movieDtos = _mapper.Map<List<MovieDto>>(movies);
            return Ok(movieDtos);
        }
    }
}
