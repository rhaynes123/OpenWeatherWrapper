using System;
using OpenWeatherWrapper.Features.Weather.Models;
using OpenWeatherWrapper.Features.Weather.Services;

namespace OpenWeatherWrapper.Features.Weather.Queries
{
    public class GetWeatherQuery
    {
        [UseFiltering]
        public async Task<IQueryable<WeatherResponse>> GetWeather([Service] IWeatherService weather)
        {
            var response = await weather.GetWeatherResponseAsync();
            return new List<WeatherResponse> { response }.AsQueryable();
        }
    }
}

