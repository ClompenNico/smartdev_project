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
            //DAILYSWITCH GOEDZETTEN

            //GlobalVariables.FileValue = "True"; //NotificationService.ReadFromFile();

            //DIT IS VOOR ALS DE APP DE EERSTE KEER WORDT OPGESTART ZODAT ER GEEN ERROR KOMT
            //Toggle value current toggle waarde geven
            //GlobalVariables.ToggleDailyValue = btnToggleDaily.On;

            //Toggle value opslaan
            //NotificationService.SaveToFile(GlobalVariables.ToggleDailyValue.ToString());

            //Toggle value ophalen
            NotificationService.ReadFromFile();

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

            //--------------DIT IS TIJDELIJK, VERGEET DIT NIET TE VERWIJDEREN
            if (GlobalVariables.FileValue == null)
            {
                lblFileValue.Text = "False";
            }
            else
            {
                lblFileValue.Text = GlobalVariables.FileValue.ToString();
            }
        }
        
        partial void MyToggleValueChanged(UISwitch sender)
        {
            GlobalVariables.ToggleDailyValue = btnToggleDaily.On;

            //GlobalVariables.ToggleDailyValue = true;
            //GlobalVariables.FileValue = "True";

            NotificationService.SaveToFile(GlobalVariables.ToggleDailyValue.ToString());

            lblValue.Text = GlobalVariables.ToggleDailyValue.ToString();
            //--------------DIT IS TIJDELIJK, VERGEET DIT NIET TE VERWIJDEREN
            if (GlobalVariables.FileValue == null)
            {
                lblFileValue.Text = "False";
            }
            else
            {
                lblFileValue.Text = GlobalVariables.FileValue.ToString();
            }
        }

        partial void BtnNotification30256_TouchUpInside(btnNotification sender)
        {

            // create the notification
            var notification = new UILocalNotification();

            // set the fire date (the date time in which it will fire)
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(5);

            // configure the alert
            //notification.AlertLaunchImage = "iconv3.png";
            
            //Watch OS
            notification.AlertAction = "View Alert!";
            //Phone
            notification.AlertTitle = "Today's prediction";
            GlobalVariables.AlertBody = "7°c Partly cloudy for the hour";
            notification.AlertBody = GlobalVariables.AlertBody;

            //notification.AlertBody = "Your one minute alert has fired!";

            // modify the badge
            notification.ApplicationIconBadgeNumber = 1;

            // set the sound to be the default sound
            notification.SoundName = UILocalNotification.DefaultSoundName;

            // schedule it
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}