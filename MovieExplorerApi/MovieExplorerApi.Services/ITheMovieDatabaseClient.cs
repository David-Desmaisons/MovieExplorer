using System.Threading.Tasks;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public interface ITheMovieDatabaseClient
    {
        Task<UpComingMovieResult> GetUpComingMoviesAsync(int page);
    }
}