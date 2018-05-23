using MvvmCross.Plugins.Messenger;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public interface IWeatherRepository
    {
        //Weer & dagen
        Task<Weather> GetWeather();
        Task<List<Weather.Daily.DailyDatas>> GetDailyDatas();
    }
}