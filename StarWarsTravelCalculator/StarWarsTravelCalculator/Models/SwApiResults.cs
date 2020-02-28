using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace StarWarsTravelCalculator.Models
{
    public class SwApiResults<T>
    {
        /// <summary>
        /// The total amount of Results data overall
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
        
        /// <summary>
        /// The URL endpoint to the next page with more results data
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }
        
        /// <summary>
        /// The URL endpoint to the previous page with more results data
        /// </summary>
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        
        /// <summary>
        /// List of T which is limited to 10 records
        /// </summary>
        [JsonPropertyName("results")]
        public List<T> Results { get; set; }
    }
}