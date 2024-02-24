using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using PublicWeatherApp.Models;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly ApplicationDbContext _context;

   public WeatherController(ApplicationDbContext context) => _context = context;

   [HttpGet]
    public async Task<IActionResult> GetWeatherData()
    {
        var weatherData = await _context.WeatherData.ToListAsync();
        return Ok(weatherData);
    }
}
