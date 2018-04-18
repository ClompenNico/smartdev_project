using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabWeekView : MvxViewController
    {
        public TabWeekView (IntPtr handle) : base (handle)
        {
        }
    }
}