using Pokemon.API.DTOs;
using Pokemon.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.Test.Services
{
    public class Mock200PokemonService : IPokemonService
    {
        public Task<PokemonDto> GetPokemonAsync(string name)
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
            return Task.Run(() => pokemonDto);
        }
    }
}
