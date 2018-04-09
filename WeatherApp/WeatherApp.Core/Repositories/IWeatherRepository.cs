﻿using System.Threading.Tasks;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public interface IWeatherRepository
    {
        Task<Weather> GetWeather();
    }
}