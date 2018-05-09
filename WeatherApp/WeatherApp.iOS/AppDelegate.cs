using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using System;
using System.Globalization;
using System.Threading;
using UIKit;
using WeatherApp.Core.Models;
using WeatherApp.Core.Repositories;
using WeatherApp.Core.Services;
using WineApp.IOS;
//using UserNotifications;

namespace WeatherApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        // class-level declarations

        private UIWindow window = UIApplication.SharedApplication.KeyWindow;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();

            try
            {
                startup.Start();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            window.MakeKeyAndVisible();

            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

            //Andere manier
            //UNUserNotificationCenter.Current.RequestAuthorization(options: UNAuthorizationOptions, completionHandler: (bool, Error) -> Void)

            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

            // check for a notification

            if (launchOptions != null)
            {
                // check for a local notification
                if (launchOptions.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
                {
                    var localNotification = launchOptions[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                    if (localNotification != null)
                    {
                        var window = UIApplication.SharedApplication.KeyWindow;

                        UIAlertController okayAlertController = UIAlertController.Create(localNotification.AlertAction, localNotification.AlertBody, UIAlertControllerStyle.Alert);
                        okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                        Window.RootViewController.PresentViewController(okayAlertController, true, null);

                        // reset our badge
                        UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                    }
                }
            }

            return true;
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            var window = UIApplication.SharedApplication.KeyWindow;
            window.RootViewController.PresentViewController(okayAlertController, true, null);

            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }
        
        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval (UIApplication.BackgroundFetchIntervalMinimum);

            DailyNotificationTask();
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.

            //reset badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.

            //DailyNotificationTask();
        }

        //TIJD NAAR BELGIESCHE TIJD VERANDEREN + 24uur ipv 12uur

        public static DateTime setBelgianTime(DateTime DateAndTime)
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Brussels");
            try
            {
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(DateAndTime, cstZone);

                return cstTime;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //protected readonly IWeatherService _weatherService;

        //DAGELIJKSE NOTIFICATIES VOOR ELKE OCHTEND

        private const double MINIMUM_BACKGROUND_FETCH_INTERVAL = 10;

        private void SetMinimumBackgroundFetchInterval()
        {
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(MINIMUM_BACKGROUND_FETCH_INTERVAL);
        }

        Weather weather;
        WeatherRepository weatherRepository = new WeatherRepository();

        public async override void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            // Check for new data, and display it
            
            weather = await weatherRepository.GetWeather();

            // Inform system of fetch results
            completionHandler(UIBackgroundFetchResult.NewData);
        }


        // Called whenever your app performs a background

        public async void DailyNotificationTask(/*IWeatherService weatherService*/)
        {
            bool Go = true;

            //_navigationService = navigationService;

            while (GlobalVariables.FileValue == "True" && Go == true)
            {
                Thread.Sleep(5000);

                //DateTime SetTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime SetTime = DateTime.Now.ToUniversalTime();
                DateTime curBEtime = setBelgianTime(SetTime);
                //DateTime resultDate = DateTime.ParseExact(SetTime, "dd/MM/yyyy - HH:mm", new CultureInfo("nl-BE"));
                //resultDate = resultDate.AddHours(+1);
                //resultDate = resultDate.AddMinutes(+1);
                //resultDate = resultDate.AddSeconds(+10);
                string curTime = curBEtime.ToString("HH:mm");
                Console.WriteLine(curTime);
                Console.WriteLine(GlobalVariables.ToggleDailyValue);
                Console.WriteLine(Go);
                Console.WriteLine("WACHTEN OP UUR");

                if (GlobalVariables.ToggleDailyValue == true && curTime == "17:55" /*DateTime.Today.Hour == 18 && DateTime.Today.Minute == 50*/)
                {
                    Go = false;
                    Console.WriteLine("NOTIFICATIE VERSTUREN!");
                    Console.WriteLine(curTime);

                    // create the notification
                    var notification = new UILocalNotification();

                    // set the fire date (the date time in which it will fire)
                    notification.FireDate = NSDate.FromTimeIntervalSinceNow(1);

                    GlobalVariables._LATITUDE = 50;
                    GlobalVariables._LONGITUDE = 3;

                    //WeatherRepository weatherRepository = new WeatherRepository();

                    //Weather weather = await weatherRepository.GetWeather();

                    // configure the alert
                    //notification.AlertLaunchImage = "iconv3.png";
                    notification.AlertTitle = "Watch Alert!";
                    notification.AlertAction = "View Alert!";
                    notification.AlertBody = weather.Currently.Summary; //"Your one minute alert has fired!";

                    // modify the badge
                    notification.ApplicationIconBadgeNumber = 1;

                    // set the sound to be the default sound
                    notification.SoundName = UILocalNotification.DefaultSoundName;

                    // schedule it
                    UIApplication.SharedApplication.ScheduleLocalNotification(notification);
                }
            }

            while (Go == false)
            {
                Thread.Sleep(5000);

                //DateTime SetTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime SetTime = DateTime.Now.ToUniversalTime();
                DateTime curBEtime = setBelgianTime(SetTime);
                //DateTime resultDate = DateTime.ParseExact(SetTime, "dd/MM/yyyy - HH:mm", new CultureInfo("nl-BE"));
                //resultDate = resultDate.AddHours(+1);
                //resultDate = resultDate.AddMinutes(+1);
                //resultDate = resultDate.AddSeconds(+10);
                string curTime = curBEtime.ToString("HH:mm");
                Console.WriteLine(curTime);
                Console.WriteLine(GlobalVariables.ToggleDailyValue);
                Console.WriteLine(Go);
                Console.WriteLine("WACHTEN OP UUR");

                if (curTime == "17:56" || curTime == "17:57")
                {
                    Go = true;
                }
            }
        }
    }
}