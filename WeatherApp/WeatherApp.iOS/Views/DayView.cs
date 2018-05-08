using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.iOS
{
    [MvxFromStoryboard(StoryboardName = "Main")]
    public partial class DayView : MvxViewController<DayViewModel>
    {
        public DayView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
        }
    }
}