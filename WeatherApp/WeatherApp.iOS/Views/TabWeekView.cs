using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabWeekView : MvxViewController<TabWeekViewModel>
    {
        public TabWeekView (IntPtr handle) : base (handle)
        {
        }
    }
}