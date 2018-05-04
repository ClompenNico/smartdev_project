using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Repositories;

namespace WeatherApp.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private static Weather _weather = new Weather();
        private static List<Weather.Daily.DailyDatas> _dailyDatas = new List<Weather.Daily.DailyDatas>();
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public async Task<Weather> GetWeather()
        {
            return await _weatherRepository.GetWeather();
        }

        public async Task<List<Weather.Daily.DailyDatas>> GetDailyDatas()
        {
            return await _weatherRepository.GetDailyDatas();
        }
    }
}
