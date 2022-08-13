using System.Text.Json.Serialization;

namespace OpenWeatherWrapper.Features.Weather.Models
{
    public record Coordindates()
    {
        [JsonPropertyName("long")]
        public decimal? Longitutde { get; set; }
        [JsonPropertyName("lat")]
        public decimal? Latitude { get; set; }
    }
}