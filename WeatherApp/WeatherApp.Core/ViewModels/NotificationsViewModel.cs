using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.File;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;

namespace WeatherApp.Core.ViewModels
{
    public class NotificationsViewModel : MvxViewModel
    {
        //protected readonly INotificationService _notificationService;

        public NotificationsViewModel()
        {
            //GlobalVariables.FileValue = "True";

            //_notificationService = notificationService;

            //NotificationService.ReadFromFile();

            //_fileStore = fileStore;

            //GlobalVariables.FileValue = "True";//NotificationService.ReadFromFile();

            /*
            if (GlobalVariables.ToggleDailyValue == true)
            {
                GlobalVariables.FileValue = NotificationService.ReadFromFile();
            }
            */
        }

        public ICommand ToggleDailyCommand
        {
            get
            {
                return new MvxCommand(() => NotificationService.SaveToFile(GlobalVariables.FileValue.ToString()));
            }
        }
    }
}
