using Pokemon.API.DTOs;
using System.Threading.Tasks;

namespace Pokemon.API.Services
{
    public interface IPokemonService
    {
        Task<PokemonDto> GetPokemonAsync(string name);
    }
}