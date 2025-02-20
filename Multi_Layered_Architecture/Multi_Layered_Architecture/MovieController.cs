using Microsoft.AspNetCore.Mvc;

namespace Multi_Layered_Architecture
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }
    }

}
