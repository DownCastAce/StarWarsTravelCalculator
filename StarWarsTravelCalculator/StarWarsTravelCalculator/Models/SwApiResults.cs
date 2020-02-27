using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWarsTravelCalculator.Models
{
    public class SwApiResults<T>
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        [JsonPropertyName("next")]
        public string Next { get; set; }
        
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        
        [JsonPropertyName("results")]
        public IList<T> Results { get; set; }
    }
}