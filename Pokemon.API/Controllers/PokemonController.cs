using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.API.Services;
using System;
using System.Threading.Tasks;

namespace Pokemon.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokemonService _pokemonRepo;
        private readonly IShakespeareTranslationService _translationService;
        public PokemonController(ILogger<PokemonController> logger, IPokemonService pokemonRepo,
            IShakespeareTranslationService translationService)
        {
            _logger = logger;
            _pokemonRepo = pokemonRepo;
            _translationService = translationService;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Models.Pokemon>> Get(string name)
        {
            try
            {
                var pokemonWrapper = await _pokemonRepo.GetPokemonAsync(name.ToLowerInvariant());                
                if (string.IsNullOrEmpty(pokemonWrapper.Description))
                    return NotFound();

                var translationWrapper = await _translationService.GetTranslationAsync(pokemonWrapper.Description);
                var pokemon = new Models.Pokemon
                {
                    Name = name,
                    Description = translationWrapper.Contents != null && !string.IsNullOrEmpty(translationWrapper.Contents.Translation) 
                    ? translationWrapper.Contents.Translation : pokemonWrapper.Description
                };
                return Ok(pokemon);                
            }          
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get pokemon {name}: {ex}");
                if (ex is ApiCallFailedException apiCallEx)                                   
                    return StatusCode((int)apiCallEx.HttpStatusCode);
                               
                return BadRequest($"Failed to get pokemon {name}");
            }
        }
    }
}
