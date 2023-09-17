using Models;
namespace WeatherObserver
{
    public class WeatherMonitor
    {
        private List<IWeatherObserver> _observers = new List<IWeatherObserver>();

        public void AddObserver(IWeatherObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers(WeatherData data)
        {
            _observers.ForEach(observer => observer.Update(data));
        }
    }
}
