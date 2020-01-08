using Microsoft.Extensions.Logging;
using Moq;
using Pokemon.API.DTOs;
using Pokemon.API.Services;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Pokemon.Test.Services
{
    public class ShakespeareTranslationServiceUnitTests
    {

        [Fact]
        public async void GetTranslation_On200Response_MustReturnATranslation()
        {            
            var shakespeareTranslationService = ServiceTestsUtilities.GetMocked200TranslationService();
            var text = "To figure on it spring season up. Her provision acuteness had excellent two why intention.";
            var translationDtoResult = await shakespeareTranslationService.GetTranslationAsync(text);

            Assert.NotNull(translationDtoResult.Contents);
            Assert.True(string.IsNullOrEmpty(translationDtoResult.Contents.Translation) == false);
        }

        [Fact]
        public async void GetTranslation_On404Response_MustThrowException()
        {          
            var shakespeareTranslationService = ServiceTestsUtilities.GetMocked404TranslationService();
            var text = "To figure on it spring season up. Her provision acuteness had excellent two why intention.";            

            await Assert.ThrowsAsync<ApiCallFailedException>(() => shakespeareTranslationService.GetTranslationAsync(text));
        }
    }
}
