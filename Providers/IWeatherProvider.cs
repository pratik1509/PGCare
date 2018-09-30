using System.Collections.Generic;
using PGCare.Models;

namespace PGCare.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
