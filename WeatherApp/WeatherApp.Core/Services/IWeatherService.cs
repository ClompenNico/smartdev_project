using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather();
        Task<List<Weather.Daily.DailyDatas>> GetDailyDatas();
    }
}