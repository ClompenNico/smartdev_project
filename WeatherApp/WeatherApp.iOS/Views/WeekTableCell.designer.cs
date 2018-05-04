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
    [Register ("WeekTableCell")]
    partial class WeekTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDag { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSummary { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTemperatuur { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgIcon != null) {
                imgIcon.Dispose ();
                imgIcon = null;
            }

            if (lblDag != null) {
                lblDag.Dispose ();
                lblDag = null;
            }

            if (lblSummary != null) {
                lblSummary.Dispose ();
                lblSummary = null;
            }

            if (lblTemperatuur != null) {
                lblTemperatuur.Dispose ();
                lblTemperatuur = null;
            }
        }
    }
}