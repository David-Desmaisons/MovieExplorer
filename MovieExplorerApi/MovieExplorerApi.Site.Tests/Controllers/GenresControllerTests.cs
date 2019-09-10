using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MovieExplorerApi.Services;
using MovieExplorerApi.Services.DTO;
using MovieExplorerApi.Site.Controllers;
using NSubstitute;
using Xunit;

namespace MovieExplorerApi.Site.Tests.Controllers
{
    public class GenresControllerTests
    {
        private readonly GenresController _MoviesController;
        private readonly ITheMovieDatabaseClient _Client;

        public GenresControllerTests()
        {
            _Client = Substitute.For<ITheMovieDatabaseClient>();
            _MoviesController = new GenresController(_Client);
        }

        [Fact]
        public async Task Get_Calls_GetAllGenresAsync()
        {
            await _MoviesController.Get();
            await _Client.Received(1).GetAllGenresAsync();
        }

        [Fact]
        public async Task Get_Returns_NotFound_When_Get_Calls_GetAllGenresAsync_Returns_Null()
        {
            _Client.GetAllGenresAsync().Returns(Task.FromResult(default(Genres)));
            var res = await _MoviesController.Get();
            res.Result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public async Task Get_UpComingMovieResult_NotFound_When_GetUpComingMoviesAsync_Returns_Null()
        {
            var result = new Genres();
            _Client.GetAllGenresAsync().Returns(Task.FromResult(result));

            var res = await _MoviesController.Get();

            res.Value.Should().Be(result);
        }
    }
}
