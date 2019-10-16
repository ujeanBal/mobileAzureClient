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

namespace FoodAppClient.iOS
{
    [Register ("BrowseItemDetailViewController")]
    partial class BrowseItemDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CarboFats { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FatsVal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ItemDescriptionLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ItemNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel KkalVal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProteinsVal { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WeightLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WeightVal { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CarboFats != null) {
                CarboFats.Dispose ();
                CarboFats = null;
            }

            if (FatsVal != null) {
                FatsVal.Dispose ();
                FatsVal = null;
            }

            if (ItemDescriptionLabel != null) {
                ItemDescriptionLabel.Dispose ();
                ItemDescriptionLabel = null;
            }

            if (ItemNameLabel != null) {
                ItemNameLabel.Dispose ();
                ItemNameLabel = null;
            }

            if (KkalVal != null) {
                KkalVal.Dispose ();
                KkalVal = null;
            }

            if (ProteinsVal != null) {
                ProteinsVal.Dispose ();
                ProteinsVal = null;
            }

            if (WeightLbl != null) {
                WeightLbl.Dispose ();
                WeightLbl = null;
            }

            if (WeightVal != null) {
                WeightVal.Dispose ();
                WeightVal = null;
            }
        }
    }
}