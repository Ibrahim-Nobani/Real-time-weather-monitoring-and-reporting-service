# Real-Time Weather Monitoring and Reporting Service

## Introduction

Welcome to the Real-Time Weather Monitoring and Reporting Service! This C# console application simulates a weather monitoring system that processes weather data from various weather stations, allowing the activation of different types of weather bots based on the received updates.

## General Task Description

The goal of this project is to design and implement a system that can handle different weather data formats (JSON, XML) and activate different weather bots based on predefined conditions.

## Supported Input Formats

### JSON Format

```json
{
  "Location": "City Name",
  "Temperature": 23.0,
  "Humidity": 85.0
}
```

### XML Format

```xml
<WeatherData>
  <Location>City Name</Location>
  <Temperature>23.0</Temperature>
  <Humidity>85.0</Humidity>
</WeatherData>
```

## Different Bot Types

1. **RainBot**: Activated when humidity exceeds a specified threshold. Outputs a predefined message.
2. **SunBot**: Activated when temperature exceeds a specified threshold. Outputs a predefined message.
3. **SnowBot**: Activated when temperature drops below a specified threshold. Outputs a predefined message.

## Interacting with the Application

1. Start the application.
2. Enter weather data in JSON or XML format.
3. The system activates bots based on the provided data and bot configurations.
4. Bots output messages if they are activated.

## Configuration Details

Bot settings are controlled via a JSON configuration file:

```json
{
  "RainBot": {
    "enabled": true,
    "humidityThreshold": 70,
    "message": "It looks like it's about to pour down!"
  },
  "SunBot": {
    "enabled": true,
    "temperatureThreshold": 30,
    "message": "Wow, it's a scorcher out there!"
  },
  "SnowBot": {
    "enabled": false,
    "temperatureThreshold": 0,
    "message": "Brrr, it's getting chilly!"
  }
}
```

## Additional Notes

This project challenges you to apply Observer and Strategy design patterns, handle file I/O operations, and manipulate data in different formats. You'll learn to react to real-time data and implement different actions based on the configuration. The system's design should allow for easy addition of new bot types or data formats without major code changes.

## Getting Started

1. Clone the repository:

   ```shell
   git clone https://github.com/Ibrahim-Nobani/Real-time-weather-monitoring-and-reporting-service.git
   ```

2. Navigate to the project directory:

   ```shell
   cd weather-monitoring
   ```

3. Build and run the application:

   ```shell
   dotnet build
   dotnet run
   ```

## License

This project is licensed under the [MIT License](LICENSE).

---