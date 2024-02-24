public class WeatherApiResponse
{
   public string Name { get; set; } // City name
   public Sys Sys { get; set; }
   public Main Main { get; set; }
   public long Dt { get; set; } // Unix timestamp
}

public class Sys
{
   public string Country { get; set; } // Country code
}

public class Main
{
   public double Temp { get; set; } // Current temperature
   public double Temp_Min { get; set; } // Min temperature
   public double Temp_Max { get; set; } // Max temperature
}
