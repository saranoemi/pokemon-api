using Pokemon.API.DTOs;
using System.Threading.Tasks;

namespace Pokemon.API.Services
{
    public interface IShakespeareTranslationService
    {
        Task<TranslationDto> GetTranslationAsync(string text);
    }
}