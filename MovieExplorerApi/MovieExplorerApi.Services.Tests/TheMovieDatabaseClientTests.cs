using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MovieExplorerApi.Services.Tests
{
    public class TheMovieDatabaseClientTests
    {
        private readonly TheMovieDatabaseClient _MovieDatabaseService;

        public TheMovieDatabaseClientTests()
        {
            var configuration = NSubstitute.Substitute.For<IConfiguration>();
            configuration["TheMovieDatabase:APIKey"] = "1f54bd990f1cdfb230adb312546d765d";
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

        [Fact]
        public async Task GetUpComingMoviesAsync_With_Portuguese_Language_Returns_Result_Not_Empty()
        {
            var culture = new CultureInfo("pt-BR");
            var result = await _MovieDatabaseService.GetUpComingMoviesAsync(1, culture);

            result.Should().NotBeNull();
            var movies = result.results;
            movies.Should().NotBeNull();
            movies.Should().NotBeEmpty();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetUpComingMoviesAsync_Returns_Required_Page(int page)
        {
            var result = await _MovieDatabaseService.GetUpComingMoviesAsync(page);

            result.Should().NotBeNull();
            result.page.Should().Be(page);
        }

        [Fact]
        public async Task GetMovieDetailAsync_Returns_Result_Not_Empty()
        {
            var id = 474350;
            var result = await _MovieDatabaseService.GetMovieDetailAsync(id);

            result.Should().NotBeNull();
            result.id.Should().Be(id);
        }
    }
}