using WeatherConfigurationInterfaces;

public class PrintingService : IPrintingService
{
    public void Print(string message)
    {
        System.Console.WriteLine(message);
    }
}