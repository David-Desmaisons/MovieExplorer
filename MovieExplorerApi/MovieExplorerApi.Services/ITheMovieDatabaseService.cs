using System.Threading.Tasks;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public interface ITheMovieDatabaseService
    {
        Task<UpComingMovieResult> GetUpComingMoviesAsync(int page);
    }
}