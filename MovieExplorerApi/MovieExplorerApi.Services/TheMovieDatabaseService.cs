using System.Net.Http;
using System.Threading.Tasks;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public class TheMovieDatabaseService : ITheMovieDatabaseService
    {
        private readonly HttpClient _Client;
        private readonly string _ApiKey;

        public TheMovieDatabaseService(HttpClient client, string apiKey)
        {
            _Client = client;
            _ApiKey = apiKey;
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
