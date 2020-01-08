using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pokemon.API;
using Pokemon.API.Services;
using Pokemon.Test.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Pokemon.Test.Controllers
{
    public class PokemonControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public PokemonControllerIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IShakespeareTranslationService, Mock200ShakespeareTranslationService>();
                    services.AddScoped<IPokemonService, Mock200PokemonService>();
                });
            }).CreateClient();            
        }

        [Fact]
        public async Task CanGetPokemonByName()
        {          
            var httpResponse = await _client.GetAsync("/pokemon/ditto");
            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var pokemon = JsonConvert.DeserializeObject<API.Models.Pokemon>(stringResponse);
            Assert.True(string.IsNullOrEmpty(pokemon.Description) == false);
            Assert.Equal("ditto", pokemon.Name);
        }
    }
}
