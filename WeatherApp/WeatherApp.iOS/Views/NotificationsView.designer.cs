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
    [Register ("NotificationsView")]
    partial class NotificationsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch btnToggleDaily { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDailySummary { get; set; }

        [Action ("BtnNotification30256_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnNotification30256_TouchUpInside (WeatherApp.iOS.btnNotification sender);

        [Action ("MyToggleValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MyToggleValueChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnToggleDaily != null) {
                btnToggleDaily.Dispose ();
                btnToggleDaily = null;
            }

            if (lblDailySummary != null) {
                lblDailySummary.Dispose ();
                lblDailySummary = null;
            }
        }
    }
}