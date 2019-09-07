using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieExplorerApi.Services;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ITheMovieDatabaseClient _MovieDatabaseClient;

        public MoviesController(ITheMovieDatabaseClient movieDatabaseClient)
        {
            _MovieDatabaseClient = movieDatabaseClient;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(UpComingMovieResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpComingMovieResult>> Get(int start)
        {
            var result = await _MovieDatabaseClient.GetUpComingMoviesAsync(start);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}
