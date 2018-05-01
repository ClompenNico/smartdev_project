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
        protected readonly INotificationService _notificationService;

        /*
        private IMvxFileStore _fileStore;
        private string _folderName = "Notifications";
        private string _fileName = "DailySummary";
        private string Tekst = GlobalVariables.ToggleDailyValue.ToString();
        */

        public NotificationsViewModel(/*IMvxFileStore fileStore, INotificationService notificationService*/)
        {
            GlobalVariables.FileValue = "True";

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
                return new MvxCommand(() => NotificationService.SaveToFile());
            }
        }
    }
}
