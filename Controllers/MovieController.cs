using Matala1_ASP.BL;
using Microsoft.AspNetCore.Mvc;

namespace Matala1_ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Movie.Read();
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public Movie? Get(int id)
        {
            return Movie.Read().FirstOrDefault(m => m.Id == id);
        }

        // POST api/<MovieController>
        [HttpPost]
        public bool Post([FromBody] Movie movie)
        {
            return Movie.Insert(movie);
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = Movie.Read().FirstOrDefault(m => m.Id == id);
            if (existingMovie == null) return false;

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Rating = updatedMovie.Rating;
            existingMovie.Income = updatedMovie.Income;
            existingMovie.ReleaseYear = updatedMovie.ReleaseYear;
            existingMovie.Duration = updatedMovie.Duration;
            existingMovie.Language = updatedMovie.Language;
            existingMovie.Description = updatedMovie.Description;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.PhotoUrl = updatedMovie.PhotoUrl;

            return true;
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var movieToDelete = Movie.Read().FirstOrDefault(m => m.Id == id);
            if (movieToDelete == null) return false;

            Movie.Read().Remove(movieToDelete);
            return true;
        }

        // GET: api/Movie/rating/{rating}
        [HttpGet("rating/{rating}")]
        public ActionResult<List<Movie>> GetByRating(double rating)
        {
            var movies = Movie.ReadByRating(rating);
            if (movies.Count == 0)
            {
                return NotFound("No movies found with the specified rating or higher.");
            }
            return Ok(movies);
        }

        // GET: api/Movie/duration?duration={duration}
        [HttpGet("duration")]
        public ActionResult<List<Movie>> GetByDuration([FromQuery] double duration)
        {
            var movies = Movie.ReadByDuration(duration);
            if (movies.Count == 0)
            {
                return NotFound("No movies found with the specified duration or less.");
            }
            return Ok(movies);
        }
    }
}
