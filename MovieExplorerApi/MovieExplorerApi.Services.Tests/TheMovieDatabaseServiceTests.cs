using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;


namespace MovieExplorerApi.Services.Tests
{
    public class TheMovieDatabaseServiceTests
    {
        private readonly TheMovieDatabaseService _MovieDatabaseService;

        public TheMovieDatabaseServiceTests()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/movie/")
            };
            _MovieDatabaseService = new TheMovieDatabaseService(client, "1f54bd990f1cdfb230adb312546d765d");
        }

        [Fact]
        public async Task GetUpComingMoviesAsync_Returns_Result_Not_Empty()
        {
            var result = await _MovieDatabaseService.GetUpComingMoviesAsync(1);

            result.Should().NotBeNull();
            var movies = result.results;
            movies.Should().NotBeNull();
            movies.Should().NotBeEmpty();
        }
    }
}
