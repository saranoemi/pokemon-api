using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace Pokemon.API.DTOs
{    
    public class TranslationDto
    {
        [JsonProperty("contents")]
        public ContentsDto Contents { get; set; }
     
    }
    public class ContentsDto
    {        
        [JsonProperty("translated")]
        public string Translation { get; set; }
    }
}
