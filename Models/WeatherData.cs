namespace Models
{
    public class WeatherData : IWeatherData
    {
        public string Location { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
    }
}