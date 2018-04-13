using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class TabDetailsView : MvxViewController<TabDetailsViewModel>
    {
        public TabDetailsView (IntPtr handle) : base (handle)
        {
        }
    }
}