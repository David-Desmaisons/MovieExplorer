using Microsoft.Extensions.Configuration;
using MovieExplorerApi.Services.DTO;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieExplorerApi.Services
{
    public class TheMovieDatabaseClient : ITheMovieDatabaseClient
    {
        private readonly HttpClient _Client;
        private readonly IConfiguration _Configuration;

        private string ApiKey => _Configuration[MovieDatabaseKey];
        private string ResourceBaseUrl => _Configuration[ResourceUrlKey];

        private const string MovieDatabaseKey = "TheMovieDatabase:APIKey";
        private const string ResourceUrlKey = "TheMovieDatabase:resourceUrl";
        private const string Format300 = "w300";
        private const string Format780 = "w780";

        public TheMovieDatabaseClient(HttpClient client, IConfiguration configuration)
        {
            _Client = client;
            _Configuration = configuration;
        }

        public async Task<UpComingMovieResult> GetUpComingMoviesAsync(int page, CultureInfo culture = null)
        {
            var query = $"{(UpdateQuery("movie/upcoming", culture))}&page={page}";
            var response = await _Client.GetAsync(query);
            var movies = await Convert<UpComingMovieResult>(response);
            return UpdateMovies(movies);
        }

        private UpComingMovieResult UpdateMovies(UpComingMovieResult movies)
        {
            if (movies?.results == null)
            {
                return movies;
            }
            foreach (var result in movies.results)
            {
                result.poster_path = UpdatePath(result.poster_path, Format300);
                result.backdrop_path = UpdatePath(result.backdrop_path, Format300);
            }
            return movies;
        }

        public async Task<MovieDetail> GetMovieDetailAsync(int movieId, CultureInfo culture = null)
        {
            var query = $"{(UpdateQuery($"movie/{movieId}", culture))}";
            var response = await _Client.GetAsync(query);
            var movie = await Convert<MovieDetail>(response);
            return UpdateMovie(movie);
        }

        private MovieDetail UpdateMovie(MovieDetail movie)
        {
            if (movie == null)
            {
                return null;
            }
            movie.poster_path = UpdatePath(movie.poster_path);
            movie.backdrop_path = UpdatePath(movie.backdrop_path);
            return movie;
        }

        private string UpdatePath(string path, string format = Format780)
        {
            return (path == null) ? null : $"{ResourceBaseUrl}{format}{path}";
        }

        public async Task<Genres> GetAllGenresAsync(CultureInfo culture = null)
        {
            var query = $"{(UpdateQuery("genre/movie/list", culture))}";
            var response = await _Client.GetAsync(query);
            return await Convert<Genres>(response);
        }

        private string UpdateQuery(string query, CultureInfo culture)
        {
            var language = culture?.Name ?? "en-US";
            return $"{query}?api_key={ApiKey}&language={language}";
        }

        private static async Task<T> Convert<T>(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ?
                await response.Content.ReadAsAsync<T>() :
                default(T);
        }
    }
}
