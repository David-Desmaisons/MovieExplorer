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
        private const string ResourcePath = "resourcePath";
        private const int Id= 474350;

        public TheMovieDatabaseClientTests()
        {
            var configuration = NSubstitute.Substitute.For<IConfiguration>();
            configuration["TheMovieDatabase:APIKey"] = "1f54bd990f1cdfb230adb312546d765d";
            configuration["TheMovieDatabase:resourceUrl"] = ResourcePath;

            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/")
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
        public async Task GetUpComingMoviesAsync_Adjust_BackDrop_Path()
        {
            var result = await _MovieDatabaseService.GetUpComingMoviesAsync(1);

            result.results[0].backdrop_path.Should().StartWith($"{ResourcePath}w300");
        }

        [Fact]
        public async Task GetUpComingMoviesAsync_Adjust_Poster_Path()
        {
            var result = await _MovieDatabaseService.GetUpComingMoviesAsync(1);

            result.results[0].poster_path.Should().StartWith($"{ResourcePath}w300");
        }

        [Fact]
        public async Task GetMovieDetailAsync_Returns_Result_Not_Empty()
        {
            var result = await _MovieDatabaseService.GetMovieDetailAsync(Id);

            result.Should().NotBeNull();
            result.id.Should().Be(Id);
        }

        [Fact]
        public async Task GetMovieDetailAsync_Adjust_BackDrop_Path()
        {
            var result = await _MovieDatabaseService.GetMovieDetailAsync(Id);

            result.backdrop_path.Should().StartWith($"{ResourcePath}w780");
        }

        [Fact]
        public async Task GetMovieDetailAsync_Adjust_Poster_Path()
        {
            var result = await _MovieDatabaseService.GetMovieDetailAsync(Id);

            result.poster_path.Should().StartWith($"{ResourcePath}w780");
        }

        [Fact]
        public async Task GetAllGenresAsync_Returns_Result_Not_Empty()
        {
            var result = await _MovieDatabaseService.GetAllGenresAsync();

            result.Should().NotBeNull();
            result.genres.Should().NotBeNull();
            result.genres.Should().NotBeEmpty();
        }
    }
}
