using Models;
namespace WeatherObserver
{
    public interface IWeatherObserver
    {
        void Update(WeatherData data);
    }
}