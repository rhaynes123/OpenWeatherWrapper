using System;
using OpenWeatherWrapper.Features.Weather.Models;

namespace OpenWeatherWrapper.Features.Weather.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;
    private readonly string ApiKey;
    private readonly string TestLat;
    private readonly string TestLong;
    public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _client = httpClientFactory.CreateClient(_configuration["OpenWeatherApi:ClientName"]);
        if (string.IsNullOrWhiteSpace(_configuration["OpenWeatherApi:APIKEY"]))
        {
            throw new ArgumentException("ApiKey Configuration Missing");
        }
        ApiKey = _configuration["OpenWeatherApi:APIKEY"];
        TestLat = _configuration["OpenWeatherApi:TestLat"];
        TestLong = _configuration["OpenWeatherApi:TestLong"];
    }

    
    public async Task<WeatherResponse> GetWeatherResponseAsync()
    {
        HttpResponseMessage response = await _client.GetAsync($"data/2.5/weather?lat={TestLat}&lon={TestLong}&appid={ApiKey}");
        if (!response.IsSuccessStatusCode || response.Content is null)
        {
            throw new Exception($"Endpoint return bad status code {response.StatusCode}");
        }
        WeatherResponse weatherdata = await response.Content.ReadFromJsonAsync<WeatherResponse>() ?? new WeatherResponse();
        return weatherdata;
    }
}

