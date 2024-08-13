using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Model.DomainModel;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class GenreController : ControllerBase
    {
        MovieDbContext movie;
        public GenreController(MovieDbContext db) {
            movie = db;
        
        }
        [HttpGet]
        [Route("/Genre/List")]
        public IActionResult GetList()
        {
            return Ok(new {data = movie.Genres.ToList()});
        }
        [HttpPost]
        [Route("/Genre/Insert")]
        public IActionResult AddGenre(int id, string name, string des) {
            Genre g = new Genre();
            g.Name = name;
            g.Description = des;
            movie.Genres.Add(g);
            movie.SaveChanges();
            return Ok(new {data = movie.Genres.ToList()});
        
        }
    }
}
