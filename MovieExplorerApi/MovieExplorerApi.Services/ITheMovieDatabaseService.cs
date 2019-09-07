using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public interface ITheMovieDatabaseService
    {
        UpComingMovieResult GetUpComingMovies(int page);
    }
}