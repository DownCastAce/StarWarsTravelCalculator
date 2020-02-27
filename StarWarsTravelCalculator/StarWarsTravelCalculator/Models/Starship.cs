using System.Text.Json.Serialization;

namespace StarWarsTravelCalculator.Models
{
    public class Starship
    {
        /// <summary>
        /// Name of the Ship
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// How much consumable food/water in time (Day/Week/Month/Year)
        /// </summary>
        [JsonPropertyName("consumables")]
        public string Consumables { get; set; }
        
        /// <summary>
        /// Speed in Mega Light per hour
        /// </summary>
        [JsonPropertyName("MGLT")]
        public string MegaLights { get; set; }
        
    }
}