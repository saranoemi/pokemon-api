using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.API.DTOs;
using Pokemon.API.Services;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Pokemon.Test.Services
{
    public class PokemonServiceUnitTests
    {

        [Fact]
        public async void GetPokemon_On200Response_MustReturnADescription()
        {          
            var pokemonService = ServiceTestsUtilities.GetMocked200PokemonService();
            var name = "dummy";
            var pokemonDtoResult = await pokemonService.GetPokemonAsync(name);

            Assert.True(string.IsNullOrEmpty(pokemonDtoResult.Description) == false);
        }

        [Fact]
        public async void GetPokemon_On404Response_MustThrowException()
        {            
            var pokemonService = ServiceTestsUtilities.GetMocked404PokemonService();
            var name = "dummy";
           
            await Assert.ThrowsAsync<ApiCallFailedException>(() => pokemonService.GetPokemonAsync(name));
        }

        [Fact]
        public async void GetPokemon_On400Response_MustThrowException()
        {
            var pokemonService = ServiceTestsUtilities.GetMocked400PokemonService();
            var name = "dummy";

            await Assert.ThrowsAsync<ApiCallFailedException>(() => pokemonService.GetPokemonAsync(name));
        }
    }
}
