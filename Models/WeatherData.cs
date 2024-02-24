using System;
using System.ComponentModel.DataAnnotations;

public class WeatherData
{
   [Key]
   public int Id { get; set; }

   [Required]
   [StringLength(100)]
   public string Country { get; set; }

   [Required]
   [StringLength(100)]
   public string City { get; set; }

   [Required]
   public double Temperature { get; set; }

   [Required]
   public DateTime LastUpdateTime { get; set; }
   [Required]
   public double MinTemperature { get; set; }
   [Required]
   public double MaxTemperature { get; set; }
}