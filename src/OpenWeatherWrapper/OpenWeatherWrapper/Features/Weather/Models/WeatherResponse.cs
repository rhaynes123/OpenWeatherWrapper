using System;
using System.Text.Json.Serialization;

namespace OpenWeatherWrapper.Features.Weather.Models
{
    public record WeatherResponse()
    {
        [JsonPropertyName("coords")]
        public Coordindates Coordindates { get; set; } = new Coordindates();
        [JsonPropertyName("main")]
        public Main? Main { get; init; } = new Main();
        [JsonPropertyName("weather")]
        public IEnumerable<Weather> Weathers { get; init; } = Enumerable.Empty<Weather>();
    }
}

