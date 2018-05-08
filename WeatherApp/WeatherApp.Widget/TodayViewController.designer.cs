// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace WeatherApp.Widget
{
    [Register ("TodayViewController")]
    partial class TodayViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTemperatuur { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblVandaag { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblSummary != null) {
                lblSummary.Dispose ();
                lblSummary = null;
            }

            if (lblTemperatuur != null) {
                lblTemperatuur.Dispose ();
                lblTemperatuur = null;
            }

            if (lblVandaag != null) {
                lblVandaag.Dispose ();
                lblVandaag = null;
            }
        }
    }
}