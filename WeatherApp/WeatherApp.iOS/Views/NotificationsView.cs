using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.File;
using System;
using UIKit;
using WeatherApp.Core.Models;
using WeatherApp.Core.Services;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class NotificationsView : MvxViewController<NotificationsViewModel>
    {
        private static IMvxFileStore _fileStore;
        private static string _folderName = "Notification";
        private static string _fileName = "DailySummary";
        private static string Tekst = GlobalVariables.ToggleDailyValue.ToString();

        public NotificationsView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            //DAILYSWITCH GOEDZETTEN

            //GlobalVariables.FileValue = "True"; //NotificationService.ReadFromFile();

            if (GlobalVariables.FileValue == "True")
            {
                btnToggleDaily.SetState(true, animated: false);
            } else if (GlobalVariables.FileValue == "False")
            {
                btnToggleDaily.SetState(false, animated: false);
            }

            //Binding

            base.ViewDidLoad();

            MvxFluentBindingDescriptionSet<NotificationsView, NotificationsViewModel> set = this.CreateBindingSet<NotificationsView, NotificationsViewModel>();

            set.Bind(btnToggleDaily).To(vm => vm.ToggleDailyCommand);
            //set.Bind(lblFileValue).To(vm => vm.);

            set.Apply();

            lblFileValue.Text = GlobalVariables.FileValue.ToString();
        }
        
        partial void MyToggleValueChanged(UISwitch sender)
        {
            GlobalVariables.ToggleDailyValue = btnToggleDaily.On;

            NotificationService.SaveToFile();

            lblValue.Text = GlobalVariables.ToggleDailyValue.ToString();
            lblFileValue.Text = GlobalVariables.FileValue.ToString();
        }

        /*
        public static void SaveToFile()
        {
            try
            {
                if (!_fileStore.FolderExists(_folderName))
                    _fileStore.EnsureFolderExists(_folderName);

                _fileStore.WriteFile(_folderName + "/" + _fileName, Tekst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */

        partial void BtnNotification30256_TouchUpInside(btnNotification sender)
        {

            // create the notification
            var notification = new UILocalNotification();

            // set the fire date (the date time in which it will fire)
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);

            // configure the alert
            //notification.AlertLaunchImage = "iconv3.png";
            notification.AlertTitle = "Watch Alert!";
            notification.AlertAction = "View Alert!";
            notification.AlertBody = "Your one minute alert has fired!";

            // modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            // set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            // schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}