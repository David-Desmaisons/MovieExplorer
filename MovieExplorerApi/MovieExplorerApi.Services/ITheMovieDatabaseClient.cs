using System.Globalization;
using System.Threading.Tasks;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public interface ITheMovieDatabaseClient
    {
        Task<UpComingMovieResult> GetUpComingMoviesAsync(int page, CultureInfo culture = null);

        Task<MovieDetail> GetMovieDetailAsync(int movieId, CultureInfo culture = null);

        Task<Genres> GetAllGenresAsync(CultureInfo culture = null);
    }
}