using System;
using OpenWeatherWrapper.Features.Weather.Models;

namespace OpenWeatherWrapper.Features.Weather.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherResponseAsync();
    }
}

