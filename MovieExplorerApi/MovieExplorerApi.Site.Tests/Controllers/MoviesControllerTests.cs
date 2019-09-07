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
    public class MoviesControllerTests
    {
        private readonly MoviesController _MoviesController;
        private readonly ITheMovieDatabaseClient _Client;

        public MoviesControllerTests()
        {
            _Client = Substitute.For<ITheMovieDatabaseClient>();
            _MoviesController = new MoviesController(_Client);
        }

        [Fact]
        public async Task Get_Calls_GetUpComingMoviesAsync()
        {
            await _MoviesController.Get();
            await _Client.Received(1).GetUpComingMoviesAsync(1);
        }

        [Fact]
        public async Task Get_Returns_NotFound_When_GetUpComingMoviesAsync_Returns_Null()
        {
            _Client.GetUpComingMoviesAsync(1).Returns(Task.FromResult(default(UpComingMovieResult)));
            var res = await _MoviesController.Get();
            res.Result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public async Task Get_UpComingMovieResult_NotFound_When_GetUpComingMoviesAsync_Returns_Null()
        {
            var result = new UpComingMovieResult();
            _Client.GetUpComingMoviesAsync(1).Returns(Task.FromResult(result));

            var res = await _MoviesController.Get();

            res.Value.Should().Be(result);
        }
    }
}
