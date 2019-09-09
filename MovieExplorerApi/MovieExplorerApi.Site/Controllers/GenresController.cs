using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieExplorerApi.Services;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ITheMovieDatabaseClient _MovieDatabaseClient;

        public GenresController(ITheMovieDatabaseClient movieDatabaseClient)
        {
            _MovieDatabaseClient = movieDatabaseClient;
        }

        // GET api/genres
        [HttpGet]
        [ProducesResponseType(typeof(Genres), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Genres>> Get()
        {
            var result = await _MovieDatabaseClient.GetAllGenresAsync();
            return GetFromResult(result);
        }

        private ActionResult<T> GetFromResult<T>(T result)
        {
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}
