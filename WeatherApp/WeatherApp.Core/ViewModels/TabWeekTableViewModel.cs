using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.ViewModels
{
    public class TabWeekTableViewModel : MvxViewModel
    {
        private readonly IWeatherService _weatherService;

        public TabWeekTableViewModel(IWeatherService weatherService)
        {
            this._weatherService = weatherService;

            LoadData();

        }

        private List<Weather.Daily.DailyDatas> _dailyDataList;
        public List<Weather.Daily.DailyDatas> DailyDataList
        {
            get { return _dailyDataList; }
            set
            {
                _dailyDataList = value;
                RaisePropertyChanged(() => DailyDataList);
            }
        }

        private async void LoadData()
        {
            DailyDataList = await _weatherService.GetDailyDatas();
        }

        /*
        public MvxCommand<Weather.Daily.DailyDatas> NavigateToDayCommand
        {
            get
            {
                return new MvxCommand<Weather.Daily.DailyDatas>(
                        selectedDay =>
                        {
                            ShowViewModel<DayViewModel>(new { dayTime = selectedDay.Day });
                        }
                    );
            }
        }
        */
    }
}
