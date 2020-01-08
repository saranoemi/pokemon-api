using Microsoft.Extensions.Logging;
using Pokemon.API.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pokemon.API.Services
{
    public class ShakespeareTranslationService : IShakespeareTranslationService
    {
        private readonly HttpClient _client;
        private readonly ILogger<ShakespeareTranslationService> _logger;

        public ShakespeareTranslationService(HttpClient client, ILogger<ShakespeareTranslationService> logger)
        {
            _client = client;
            _logger = logger;
        }
    
        public async Task<TranslationDto> GetTranslationAsync(string text)
        {
            var result = new TranslationDto();
            var encoded = Uri.EscapeUriString(text);

            var request = new HttpRequestMessage(HttpMethod.Post, $"shakespeare.json?text={encoded}");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //NOTE: you can make only 5 calls per hour to this service without a subscription.
            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<TranslationDto>();
                }
                else
                {
                    _logger.LogWarning($"Funtranslations returns not successful status code: {response.StatusCode}");
                    throw new ApiCallFailedException(response.StatusCode);
                }
            }                    

            return result;
        }
    }
}
