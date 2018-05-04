using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using System;
using UIKit;
using WeatherApp.Core.Models;
using WeatherApp.iOS.Converters;

namespace WeatherApp.iOS
{
    public partial class WeekTableCell : MvxTableViewCell
    {
        public WeekTableCell (IntPtr handle) : base (handle)
        {
        }

        internal static readonly NSString Identifier = new NSString("WeekCell");

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            MvxFluentBindingDescriptionSet<WeekTableCell, Weather.Daily.DailyDatas> set = new MvxFluentBindingDescriptionSet<WeekTableCell, Weather.Daily.DailyDatas>(this);
            
            set.Bind(lblDag).To(vm => vm.Day);

            set.Bind(lblSummary).To(vm => vm.Summary);

            set.Bind(lblTemperatuur).To(vm => vm.TempHigh);

            set.Bind(imgIcon)
                .For(img => img.Image)
                .To(vm => vm.Icon)
                .WithConversion<StringToImageConverter>();

            set.Apply();


            //============BACKGROUND COLOR INSTELLEN================
            int currentTime = DateTime.Now.Hour;

            if (currentTime <= 6 || currentTime >= 21)
            {
                this.BackgroundColor = UIColor.FromRGB(27, 41, 54);
            }
            else if (currentTime <= 9 || currentTime >= 18 && currentTime <= 21)
            {
                this.BackgroundColor = UIColor.FromRGB(174, 111, 37);
            }
            else if (currentTime <= 18)
            {
                this.BackgroundColor = UIColor.FromRGB(49, 89, 94);
            }
            else
            {
                this.BackgroundColor = UIColor.FromRGB(49, 89, 94);
            }

        }
    }
}