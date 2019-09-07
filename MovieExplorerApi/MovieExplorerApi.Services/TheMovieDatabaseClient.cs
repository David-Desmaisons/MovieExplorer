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
        private const string MdbKey = "TMDBKey";

        public TheMovieDatabaseClient(HttpClient client, IConfiguration configuration)
        {
            _Client = client;
            _ApiKey = configuration[MdbKey];
        }

        public async Task<UpComingMovieResult> GetUpComingMoviesAsync(int page)
        {
            var query = $"upcoming?api_key={_ApiKey}&page={page}";
            var response = await _Client.GetAsync(query);
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsAsync<UpComingMovieResult>();
        }
    }
}
