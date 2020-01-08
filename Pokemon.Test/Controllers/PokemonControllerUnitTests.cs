using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.API.Controllers;
using Pokemon.Test.Services;
using Xunit;

namespace Pokemon.Test.Controllers
{
    public class PokemonControllerUnitTests
    {
        [Fact]
        public async void Get_WhenServicesReturn200_ReturnsOkResult()
        {
            var logger = Mock.Of<ILogger<PokemonController>>();
            var controller = new PokemonController(logger, new Mock200PokemonService(), new Mock200ShakespeareTranslationService());

            var result = await controller.Get("dummy");

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async void Get_WhenPokemonServiceReturns404_ReturnsNotFoundResult()
        {
            var logger = Mock.Of<ILogger<PokemonController>>();
            var controller = new PokemonController(logger, ServiceTestsUtilities.GetMocked404PokemonService(), new Mock200ShakespeareTranslationService());

            var result = await controller.Get("dummy");
            var statusCodeResult = result.Result as StatusCodeResult;
            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void Get_WhenTranslationServiceReturns404_ReturnsOkResult()
        {
            var logger = Mock.Of<ILogger<PokemonController>>();
            var controller = new PokemonController(logger, ServiceTestsUtilities.GetMocked404PokemonService(), new Mock200ShakespeareTranslationService());

            var result = await controller.Get("dummy");
            var statusCodeResult = result.Result as StatusCodeResult;
            Assert.Equal(StatusCodes.Status404NotFound, statusCodeResult.StatusCode);            
        }
    }
}
