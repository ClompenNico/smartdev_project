using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross.Core.Platform;
using MvvmCross.Core.Views;
using MvvmCross.Platform.Core;
using MvvmCross.Test.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;
using WeatherApp.Core.ViewModels;
using static WeatherApp.Core.Models.Weather;

namespace WeatherApp.Tests
{
    [TestClass]
    public class WeatherViewModelTest : MvxIoCSupportingTest
    {
        protected MockDispatcher MockDispatcher;

        protected override void AdditionalSetup()
        {
            base.AdditionalSetup();
            MockDispatcher = new MockDispatcher();
            Ioc.RegisterSingleton<IMvxViewDispatcher>(MockDispatcher);
            Ioc.RegisterSingleton<IMvxMainThreadDispatcher>(MockDispatcher);
            // required only when passing parameters
            Ioc.RegisterSingleton<IMvxStringToTypeParser>(new MvxStringToTypeParser());
        }

        [TestMethod]
        public void Weather_Property_Return_CurrentPos()
        {
            // ARRANGE || FAKE WAARDEN AANMAKEN
            var weather = new Weather
            {
                Currently = new Currently { },
                Latitude = 3.666,
                Longitude = 50.333,
                Timezone = DateTime.Now.ToString(),
                Minutely = new Minutely { },
                _Hourly = new Hourly { },
                _Daily = new Daily { },
            };

            //SERVICE MOCKEN
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(ps => ps.GetWeather()).Returns(Task.FromResult(weather));
            var vm = new WeatherTabsViewModel(mockWeatherService.Object);

            // ACT
            var currentPos = vm.Weather;

            // ASSERT
            Assert.IsNull(currentPos);
        }

        [TestMethod]
        public void Weather_Property_Return_WeeklyPrediction()
        {
            // ARRANGE || FAKE WAARDEN AANMAKEN
            var dailydatas = new List<Weather.Daily.DailyDatas>();
            dailydatas.Add(new Weather.Daily.DailyDatas() { Time = 15, Day = "Monday", Summary = "Good day", Icon = "Sun", TemperatureHigh = 21, TemperatureLow = 13, TempHigh = "21 °c" });
            dailydatas.Add(new Weather.Daily.DailyDatas() { Time = 16, Day = "Tuesday", Summary = "Bad day", Icon = "Rain", TemperatureHigh = 18, TemperatureLow = 12, TempHigh = "18 °c" });

            //SERVICE MOCKEN
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(ps => ps.GetDailyDatas()).Returns(Task.FromResult(dailydatas));
            var vm = new WeatherTabsViewModel(mockWeatherService.Object);

            // ACT
            var weeklyPred = vm.DailyDataList;

            //ASSERT
            Assert.IsNull(weeklyPred);

        }
    }
}
