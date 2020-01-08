using Pokemon.API.DTOs;
using Pokemon.API.Services;
using System.Threading.Tasks;

namespace Pokemon.Test.Services
{
    public class Mock200ShakespeareTranslationService : IShakespeareTranslationService
    {       
        public Task<TranslationDto> GetTranslationAsync(string text)
        {
            var translationDto = new TranslationDto
            {
                Contents = new ContentsDto
                {
                    Translation = "To figure on t springeth season up. H'r provision acuteness hadst excellent two wherefore intention"
                }
            };   
            return Task.Run(() => translationDto);
        }
    }
}
