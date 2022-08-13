
using OpenWeatherWrapper.Features.Weather.Queries;
using OpenWeatherWrapper.Features.Weather.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient(name: builder.Configuration["OpenWeatherApi:ClientName"], configureClient: client =>
{
    client.BaseAddress = new Uri("http://api.openweathermap.org/");

});
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddGraphQLServer().AddFiltering().AddQueryType<GetWeatherQuery>();
var app = builder.Build();
app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());
app.MapGet("/", () => "");

app.Run();

