using MvvmCross.Plugins.Messenger;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public interface IWeatherRepository
    {
        Task<Weather> GetWeather();
    }
}