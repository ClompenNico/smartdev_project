// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WeatherApp.iOS
{
    [Register ("WeatherView")]
    partial class WeatherView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHourSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLatitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLongitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTemperature { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgIcon != null) {
                imgIcon.Dispose ();
                imgIcon = null;
            }

            if (lblHourSummary != null) {
                lblHourSummary.Dispose ();
                lblHourSummary = null;
            }

            if (lblLatitude != null) {
                lblLatitude.Dispose ();
                lblLatitude = null;
            }

            if (lblLongitude != null) {
                lblLongitude.Dispose ();
                lblLongitude = null;
            }

            if (lblSummary != null) {
                lblSummary.Dispose ();
                lblSummary = null;
            }

            if (lblTemperature != null) {
                lblTemperature.Dispose ();
                lblTemperature = null;
            }
        }
    }
}