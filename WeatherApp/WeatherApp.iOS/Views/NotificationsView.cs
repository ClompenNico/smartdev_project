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
        public NotificationsView (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            //Toggle value ophalen voor switch
            NotificationService.ReadFromFile();

            //Switch correct togglen voor als app opstart
            if (GlobalVariables.FileValue == "True")
            {
                btnToggleDaily.SetState(true, animated: false);
            } else if (GlobalVariables.FileValue == "False")
            {
                btnToggleDaily.SetState(false, animated: false);
            }

            base.ViewDidLoad();

            //Binding
            MvxFluentBindingDescriptionSet<NotificationsView, NotificationsViewModel> set = this.CreateBindingSet<NotificationsView, NotificationsViewModel>();

            set.Bind(btnToggleDaily).To(vm => vm.ToggleDailyCommand);

            set.Apply();
        }
        
        partial void MyToggleValueChanged(UISwitch sender)
        {
            //Globale variabele opvullen met status van de switch
            GlobalVariables.ToggleDailyValue = btnToggleDaily.On;

            //Daily notificatie status opslaan in file
            NotificationService.SaveToFile(GlobalVariables.ToggleDailyValue.ToString());
        }


        //Test button voor notificatie te sturen
        partial void BtnNotification30256_TouchUpInside(btnNotification sender)
        {

            // create the notification
            var notification = new UILocalNotification();

            // set the fire date (the date time in which it will fire)
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);

            // configure the alert
            string body = GlobalVariables.weatherUpdate.Currently.Temp + " " + GlobalVariables.weatherUpdate.Currently.Summary;
            //notification.AlertLaunchImage = "iconv3.png";
            notification.AlertAction = "Today's prediction"; //Watch Alert
            notification.AlertTitle = "Today's prediction"; //View Alert
            notification.AlertBody = body;

            // modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            // set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            // schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}