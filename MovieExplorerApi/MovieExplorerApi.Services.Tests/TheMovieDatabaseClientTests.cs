using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace MovieExplorerApi.Services.Tests
{
    public class TheMovieDatabaseClientTests
    {
        private readonly TheMovieDatabaseClient _MovieDatabaseService;

        public TheMovieDatabaseClientTests()
        {
            var configuration = NSubstitute.Substitute.For<IConfiguration>();
            configuration["TMDBKey"] = "1f54bd990f1cdfb230adb312546d765d";
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/movie/")
            };
            _MovieDatabaseService = new TheMovieDatabaseClient(client, configuration);
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
