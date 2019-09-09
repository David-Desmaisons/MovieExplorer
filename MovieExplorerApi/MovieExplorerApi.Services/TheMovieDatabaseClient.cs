using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public class TheMovieDatabaseClient : ITheMovieDatabaseClient
    {
        private readonly HttpClient _Client;
        private readonly string _ApiKey;
        private const string MovieDatabaseKey = "TheMovieDatabase:APIKey";

        public TheMovieDatabaseClient(HttpClient client, IConfiguration configuration)
        {
            _Client = client;
            _ApiKey = configuration[MovieDatabaseKey];
        }

        public async Task<UpComingMovieResult> GetUpComingMoviesAsync(int page, CultureInfo culture=null)
        {
            var query = $"{(UpdateQuery("movie/upcoming", culture))}&page={page}";
            var response = await _Client.GetAsync(query);
            return await Convert<UpComingMovieResult>(response);
        }

        public async Task<MovieDetail> GetMovieDetailAsync(int movieId, CultureInfo culture = null)
        {
            var query = $"{(UpdateQuery($"movie/{movieId}", culture))}";
            var response = await _Client.GetAsync(query);
            return await Convert<MovieDetail>(response);
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
            return $"{query}?api_key={_ApiKey}&language={language}";
        }

        private static async Task<T> Convert<T>(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode ? 
                await response.Content.ReadAsAsync<T>() : 
                default(T);
        }
    }
}
