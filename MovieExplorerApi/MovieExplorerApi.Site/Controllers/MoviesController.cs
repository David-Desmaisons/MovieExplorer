using System.Collections.Generic;
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
        public async Task<ActionResult<UpComingMovieResult>> Get()
        {
            return await _MovieDatabaseClient.GetUpComingMoviesAsync(1);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return NotFound();
        }
    }
}
