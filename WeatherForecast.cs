using Azure;
using NewShoreTest.Models.ApiModels;
using NewShoreTest.Models.BusinessModels;

namespace NewShoreTest
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }

        public ResponseObj Response { get; set; } = null!;
    }
}
