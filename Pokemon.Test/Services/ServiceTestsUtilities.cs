using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.API.DTOs;
using Pokemon.API.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Pokemon.Test.Services
{
    public class ServiceTestsUtilities
    {
        public static IPokemonService GetMocked404PokemonService()
        {
            var httpClient = new HttpClient(new GenericServiceReturn404ResponseHandler())
            {
                BaseAddress = new System.Uri("http://dummy.com/")
            };
            var logger = Mock.Of<ILogger<PokemonService>>();

            return new PokemonService(httpClient, logger);
        }

        public static IPokemonService GetMocked400PokemonService()
        {
            var httpClient = new HttpClient(new GenericServiceReturn400ResponseHandler())
            {
                BaseAddress = new System.Uri("http://dummy.com/")
            };
            var logger = Mock.Of<ILogger<PokemonService>>();

            return new PokemonService(httpClient, logger);
        }

        public static IPokemonService GetMocked200PokemonService()
        {
            var pokemonDto = new PokemonDto
            {
                FlavorTextEntries = new List<FlavorTextDto>()
                {
                    new FlavorTextDto
                    {
                        Language = new LanguageDto { Name = "en"},
                        Text = "By so delight of showing neither believe he present.Deal sigh up in shew away when.Pursuit express no or prepare replied.Wholly formed old latter future but way she."
                    }
                }
            };
            var httpClient = new HttpClient(new GenericServiceReturn200ResponseHandler<PokemonDto>(pokemonDto))
            {
                BaseAddress = new System.Uri("http://dummy.com/")
            };
            var logger = Mock.Of<ILogger<PokemonService>>();

            return new PokemonService(httpClient, logger);
        }

        public static IShakespeareTranslationService GetMocked404TranslationService()
        {
            var httpClient = new HttpClient(new GenericServiceReturn404ResponseHandler())
            {
                BaseAddress = new System.Uri("http://dummy.com/")
            };
            var logger = Mock.Of<ILogger<ShakespeareTranslationService>>();

            return new ShakespeareTranslationService(httpClient, logger);
        }

        public static IShakespeareTranslationService GetMocked200TranslationService()
        {
            var translationDto = new TranslationDto
            {
                Contents = new ContentsDto
                {
                    Translation = "To figure on t springeth season up. H'r provision acuteness hadst excellent two wherefore intention"
                }
            };
            var httpClient = new HttpClient(new GenericServiceReturn200ResponseHandler<TranslationDto>(translationDto))
            {
                BaseAddress = new System.Uri("http://dummy.com/")
            };
            var logger = Mock.Of<ILogger<ShakespeareTranslationService>>();

            return new ShakespeareTranslationService(httpClient, logger);
        }
    }
}
