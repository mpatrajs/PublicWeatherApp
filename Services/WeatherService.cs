using Newtonsoft.Json;
using PublicWeatherApp.Models;
using PublicWeatherApp.Services;

public class WeatherService : IWeatherService
{
    private readonly ApplicationDbContext _context;
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "61ec766e94b317659f1146fb9f6dda77"; // Consider fetching this from configuration

    public WeatherService(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClient = httpClientFactory.CreateClient();
    }

   public async Task UpdateWeatherDataAsync()
   {
      var cities = new List<string> { "Riga,lv", "Tokyo,jp", "New York,us", "London,uk" };

      foreach (var city in cities)
      {
         string requestUri = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";

         var response = await _httpClient.GetAsync(requestUri);
         if (response.IsSuccessStatusCode)
         {
            var content = await response.Content.ReadAsStringAsync();
            var weatherApiResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(content);

            var weatherData = new WeatherData
            {
               City = weatherApiResponse.Name,
               Country = weatherApiResponse.Sys.Country,
               Temperature = weatherApiResponse.Main.Temp,
               MinTemperature = weatherApiResponse.Main.Temp_Min,
               MaxTemperature = weatherApiResponse.Main.Temp_Max,
               LastUpdateTime = DateTimeOffset.FromUnixTimeSeconds(weatherApiResponse.Dt).DateTime
            };

            _context.WeatherData.Add(weatherData);
         }
      }

      await _context.SaveChangesAsync();
   }
}
