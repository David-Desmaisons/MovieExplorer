using System.Threading.Tasks;
using AutoFixture.Xunit2;
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

        [Theory,AutoData]
        public async Task Get_Calls_GetUpComingMoviesAsync(int page)
        {
            await _MoviesController.Get(page);
            await _Client.Received(1).GetUpComingMoviesAsync(page);
        }

        [Theory, AutoData]
        public async Task Get_Returns_NotFound_When_GetUpComingMoviesAsync_Returns_Null(int page)
        {
            _Client.GetUpComingMoviesAsync(page).Returns(Task.FromResult(default(UpComingMovieResult)));
            var res = await _MoviesController.Get(page);
            res.Result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Theory, AutoData]
        public async Task Get_UpComingMovieResult_NotFound_When_GetUpComingMoviesAsync_Returns_Null(int page)
        {
            var result = new UpComingMovieResult();
            _Client.GetUpComingMoviesAsync(page).Returns(Task.FromResult(result));

            var res = await _MoviesController.Get(page);

            res.Value.Should().Be(result);
        }

        [Theory, AutoData]
        public async Task GetMovie_Calls_GetMovieDetailAsync(int id)
        {
            await _MoviesController.GetMovie(id);
            await _Client.Received(1).GetMovieDetailAsync(id);
        }

        [Theory, AutoData]
        public async Task GetMovie_Returns_NotFound_When_GetUpComingMoviesAsync_Returns_Null(int id)
        {
            _Client.GetMovieDetailAsync(id).Returns(Task.FromResult(default(MovieDetail)));
            var res = await _MoviesController.GetMovie(id);
            res.Result.Should().BeAssignableTo<NotFoundResult>();
        }

        [Theory, AutoData]
        public async Task GetMovie_UpComingMovieResult_NotFound_When_GetUpComingMoviesAsync_Returns_Null(int id)
        {
            var result = new MovieDetail();
            _Client.GetMovieDetailAsync(id).Returns(Task.FromResult(result));

            var res = await _MoviesController.GetMovie(id);

            res.Value.Should().Be(result);
        }
    }
}
