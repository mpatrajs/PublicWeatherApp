using Microsoft.EntityFrameworkCore;

namespace PublicWeatherApp.Models
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }

      public DbSet<WeatherData> WeatherData { get; set; }

      // Optionally override the OnModelCreating method
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Define relationships, configure constraints, etc.
         base.OnModelCreating(modelBuilder);
      }
   }
}
