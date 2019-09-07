using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public interface ITheMovieDatabaseServices
    {
        UpComingMovieResult GetUpComingMovies(int page);
    }
}