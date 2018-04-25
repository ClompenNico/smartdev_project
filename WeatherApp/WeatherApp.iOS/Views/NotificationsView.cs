using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.Models;
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
            base.ViewDidLoad();

            SendNotification();
        }

        public void SendNotification()
        {
            /*
            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(1);
            //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications
            notification.AlertAction = "View Alert";
            notification.AlertBody = "Your 1 second alert has fired!";
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            */
        }

        /*
        partial void BtnNotification_TouchUpInside(btnNotification sender)
        {
            
        }

        partial void BtnNotification_TouchUpInside()
        {
            throw new NotImplementedException();
        }
        */

        partial void MyToggleValueChanged(UISwitch sender)
        {
            GlobalVariables.ToggleDailyValue = btnToggleDaily.On;

            lblValue.Text = GlobalVariables.ToggleDailyValue.ToString();
        }

        partial void BtnNotification30256_TouchUpInside(btnNotification sender)
        {
            /*
            UIAlertView alert = new UIAlertView()
            {
                Title = "Labo 1",
                Message = "Hello Xamarin"
            };
            alert.AddButton("OK");
            alert.Show();

            UILocalNotification notification = new UILocalNotification();
            NSDate.FromTimeIntervalSinceNow(1);
            //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications
            notification.AlertAction = "View Alert";
            notification.AlertBody = "Your 1 second alert has fired!";
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
            */

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