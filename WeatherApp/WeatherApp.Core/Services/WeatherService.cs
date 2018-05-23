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

        //DI
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
            GetWeatherUpdate();
        }

        //WEER
        public async Task<Weather> GetWeather()
        {
            return await _weatherRepository.GetWeather();
        }

        //LIJST DAGEN
        public async Task<List<Weather.Daily.DailyDatas>> GetDailyDatas()
        {
            return await _weatherRepository.GetDailyDatas();
        }

        //Update voor local notificatie voor in appdelegate
        public async void GetWeatherUpdate()
        {
            GlobalVariables.weatherUpdate = await _weatherRepository.GetWeather();
        }
    }
}
