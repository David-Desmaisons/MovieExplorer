using System;
using System.Net.Http;
using MovieExplorerApi.Services.DTO;

namespace MovieExplorerApi.Services
{
    public class TheMovieDatabaseService : ITheMovieDatabaseService
    {
        private readonly HttpClient _Client;

        public TheMovieDatabaseService(HttpClient client)
        {
            _Client = client;
        }

        public UpComingMovieResult GetUpComingMovies(int page)
        {
            throw new NotImplementedException();
        }
    }
}
