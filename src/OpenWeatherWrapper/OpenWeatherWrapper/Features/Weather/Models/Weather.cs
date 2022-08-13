using System;
using System.Text.Json.Serialization;

namespace OpenWeatherWrapper.Features.Weather.Models
{
    public record Weather
    {
        [JsonPropertyName("id"), ID]
        public int? Id { get; init; }
        [JsonPropertyName("main")]
        public string? Main { get; init; }
        [JsonPropertyName("description")]
        public string? Description { get; init; }
        [JsonPropertyName("icon")]
        public string? Icon { get; init; }
    }
}

