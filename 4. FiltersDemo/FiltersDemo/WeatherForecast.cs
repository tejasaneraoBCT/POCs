using System.ComponentModel.DataAnnotations;

namespace FiltersDemo
{
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Range(-60, 80)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        [MaxLength(300)]
        public string? Summary { get; set; }
    }
}