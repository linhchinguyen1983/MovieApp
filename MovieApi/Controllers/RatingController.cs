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
    public class RatingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRatingRepository _ratingRepository;
        public RatingController(IMapper mapper, IRatingRepository ratingRepository) 
        {
            _mapper = mapper;
            _ratingRepository = ratingRepository;
        }
        [HttpPost]
        [Route("rating")]
        public async Task<IActionResult> AddRatingAsync([FromBody] AddRatingDto addRatingDto)
        {
            try
            {
                var rating = _mapper.Map<Rating>(addRatingDto);
                var newRating = await _ratingRepository.AddRatingAsync(rating);

                if (newRating == null)
                {
                    return BadRequest("Invalid rating or rating already exists.");
                }

                return Ok(_mapper.Map<RatingDto>(newRating));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // Conflict 409 for already existing rating
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{movieId}/avgRating")]
        public async Task<IActionResult> AvgRating([FromRoute] Guid movieId)
        {
            try
            {
                var avgRating = await _ratingRepository.AvgRating(movieId);
                return Ok(avgRating);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
