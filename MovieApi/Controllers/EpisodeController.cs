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
    public class EpisodeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEpisodeRepository _episodeRepository;
        public EpisodeController (IMapper mapper, IEpisodeRepository episodeRepository)
        {
            _mapper = mapper;
            _episodeRepository = episodeRepository;
        }
        [HttpGet]
        [Route("{movieId}/episode")]
        public async Task<IActionResult> GetAllEpisode([FromRoute] Guid movieId)
        {
            var episodes = await _episodeRepository.GetAllEpisodeAsync(movieId);
            var episodeDtos = _mapper.Map<List<EpisodeDto>>(episodes);  // Ánh xạ thành danh sách
            return Ok(episodeDtos);
        }


        [HttpGet]
        [Route("{movieId}/episode/{id}")]
        public async Task<IActionResult> GetEpisode([FromRoute] Guid movieId, [FromRoute] Guid id)
        {
            var episode = await _episodeRepository.GetEpisodeByIdAsync(id, movieId);
            if (episode == null)
            {
                return NotFound(new { result = "Resource not found!" });
            }
            var episodeDto = _mapper.Map<EpisodeDto>(episode);
            return Ok(episodeDto);
        }


        [HttpPost]
        [Route("episode")]
        public async Task<IActionResult> AddEpisode([FromBody] AddEpisodeDto addEpisodeDto)
        {
            var episode = _mapper.Map<Episode>(addEpisodeDto);
            var newEpisode = await _episodeRepository.AddEpisodeAsync(episode);
            return Ok(_mapper.Map<EpisodeDto>(newEpisode));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateEpisode([FromRoute] Guid id, [FromBody] UpdateEpisodeDto updateEpisodeDto)
        {
            if (!ModelState.IsValid) 
            {  
                return BadRequest(ModelState); 
            }
            var episode = _mapper.Map<Episode>(updateEpisodeDto);
            var updateEp = await _episodeRepository.UpdateEpisodeAsync(id,episode);
            if(updateEp == null) { return StatusCode(500); }
            return Ok(_mapper.Map<EpisodeDto>(updateEp));

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEpisode([FromRoute] Guid id)
        {
            var isDelete = await _episodeRepository.DeleteEpisodeAsync(id);
            if (isDelete) return Ok("Delete Successed");
            else return BadRequest("Delete Failed!");
        }

    }
}
