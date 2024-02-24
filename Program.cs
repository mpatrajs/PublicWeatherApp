using PublicWeatherApp.Models;
using Microsoft.EntityFrameworkCore;
using PublicWeatherApp.Services;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register IHttpClientFactory
builder.Services.AddHttpClient();

// Register ApplicationDbContext with the correct connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

// Register IWeatherService and its implementation
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Register WeatherDataUpdateService as a hosted service
builder.Services.AddHostedService<WeatherDataUpdateService>();

// Add controllers with views (if using MVC)
builder.Services.AddControllersWithViews();

// Add Razor Pages (if using)
// builder.Services.AddRazorPages();

// Add authorization services
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Home/Error");
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ensure authentication middleware is used when authorization is needed
// app.UseAuthentication(); // Uncomment if using authentication

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages (if using)
// app.MapRazorPages();

app.Run();
