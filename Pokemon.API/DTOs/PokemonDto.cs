using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Pokemon.API.DTOs
{
    public class LanguageDto
    {       
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FlavorTextDto
    {        
        [JsonProperty("flavor_text")]
        public string Text { get; set; }
       
        [JsonProperty("language")]
        public LanguageDto Language { get; set; }
    }

    public class PokemonDto
    {
        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextDto> FlavorTextEntries { get; set; }

        public string Description
        {
            get
            {
                var result = string.Empty;
                if (FlavorTextEntries == null || FlavorTextEntries.Count == 0)
                    return result;
                var firstEnDescription = FlavorTextEntries
                    .FirstOrDefault(entry => entry.Language != null && entry.Language.Name == "en");                    
                if (firstEnDescription == null)
                    return result;
                
                return firstEnDescription.Text.Replace('\n', ' ');
            }
        }
    }
}
