﻿using MvvmCross.Plugins.Messenger;
using NMCT.Resto.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Messages;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.Repositories
{
    public class WeatherRepository : BaseRepository, IWeatherRepository
    {
        //BASE URL & UNITS
        private const string _BASEURL = "https://api.darksky.net/forecast/";
        string _PARAMETER = "units=auto";

        //Weer opvragen
        public Task<Weather>GetWeather()
        {
            string url = String.Format("{0}{1}/{2},{3}?{4}", _BASEURL, _API_KEY, GlobalVariables._LATITUDE, GlobalVariables._LONGITUDE, _PARAMETER);
            return GetAsync<Weather>(url);
        }

        //List van dagen
        public async Task<List<Weather.Daily.DailyDatas>>GetDailyDatas()
        {
            string url = String.Format("{0}{1}/{2},{3}?{4}", _BASEURL, _API_KEY, GlobalVariables._LATITUDE, GlobalVariables._LONGITUDE, _PARAMETER);
            List<Weather.Daily.DailyDatas> dailyDatas = (await GetAsync<Weather>(url))._Daily.dailyDatas;
            return dailyDatas;
            //return GetAsync<List<Daily.DailyDatas>>(url);
        }
    }
}
