using Microsoft.EntityFrameworkCore;
using PublicWeatherApp.Models;
using PublicWeatherApp.Services;

namespace PublicWeatherApp
{
   public class Startup
   {
      public Startup(IConfiguration configuration) => Configuration = configuration;

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         // Add services to the container.
         services.AddHttpClient();
         services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         services.AddScoped<IWeatherService, WeatherService>();
         services.AddHostedService<WeatherDataUpdateService>();
         services.AddControllersWithViews();
         services.AddAuthorization();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         // Configuration for various environments
      }
   }
}
