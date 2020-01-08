using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pokemon.API.DTOs;

namespace Pokemon.API.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _client;
        private readonly ILogger<PokemonService> _logger;

        public PokemonService(HttpClient client, ILogger<PokemonService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<PokemonDto> GetPokemonAsync(string name)
        {
            var pokemonWrapper = new PokemonDto();

            var request = new HttpRequestMessage(HttpMethod.Get, $"pokemon-species/{name}/");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {               
                if (response.IsSuccessStatusCode)
                {
                    pokemonWrapper = await response.Content.ReadAsAsync<PokemonDto>();
                }
                else
                {
                    _logger.LogWarning($"Pokeapi returns not successful status code: {response.StatusCode}");                 
                    throw new ApiCallFailedException(response.StatusCode);
                }
            }

            return pokemonWrapper;
        }
        
    }
}
