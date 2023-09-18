using Models;
using Moq;
using WeatherConfigurationInterfaces;
using WeatherObserver;
using Xunit;

namespace WeatherObserverTests
{
    public class WeatherObserverTests
    {
        [Fact]
        public void WeatherMonitor_NotifiesObservers_ShouldUpdateObservers()
        {
            // Arrange
            var monitor = new WeatherMonitor();
            var mockObserver1 = new Mock<IWeatherObserver>();
            var mockObserver2 = new Mock<IWeatherObserver>();
            var weatherData = new WeatherData();

            monitor.AddObserver(mockObserver1.Object);
            monitor.AddObserver(mockObserver2.Object);

            // Act
            monitor.NotifyObservers(weatherData);

            // Assert
            mockObserver1.Verify(observer => observer.Update(weatherData), Times.Once);
            mockObserver2.Verify(observer => observer.Update(weatherData), Times.Once);
        }
        [Fact]
        public void WeatherBotObserver_UpdatesWeatherBot_ShouldCallProcessWeatherData()
        {
            // Arrange
            var mockWeatherBot = new Mock<IWeatherBot>();
            var weatherBotObserver = new WeatherBotObserver(mockWeatherBot.Object);
            var weatherData = new WeatherData();

            // Act
            weatherBotObserver.Update(weatherData);

            // Assert
            mockWeatherBot.Verify(bot => bot.ProcessWeatherData(weatherData), Times.Once);
        }
    }
}
