using PublicWeatherApp.Services;

public class WeatherDataUpdateService : BackgroundService
{
   private readonly IServiceProvider _serviceProvider;

   public WeatherDataUpdateService(IServiceProvider serviceProvider)
   {
      _serviceProvider = serviceProvider;
   }

   protected override async Task ExecuteAsync(CancellationToken stoppingToken)
   {
      using (var scope = _serviceProvider.CreateScope())
      {
         var weatherService = scope.ServiceProvider.GetRequiredService<IWeatherService>();

         while (!stoppingToken.IsCancellationRequested)
         {
            await weatherService.UpdateWeatherDataAsync();
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
         }
      }
   }
}
