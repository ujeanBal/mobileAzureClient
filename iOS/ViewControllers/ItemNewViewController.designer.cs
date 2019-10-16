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
    [Register ("ItemNewViewController")]
    partial class ItemNewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField bind { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSaveItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField CarboField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FatsField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PfcView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ProteinField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWeight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (bind != null) {
                bind.Dispose ();
                bind = null;
            }

            if (btnSaveItem != null) {
                btnSaveItem.Dispose ();
                btnSaveItem = null;
            }

            if (CarboField != null) {
                CarboField.Dispose ();
                CarboField = null;
            }

            if (FatsField != null) {
                FatsField.Dispose ();
                FatsField = null;
            }

            if (PfcView != null) {
                PfcView.Dispose ();
                PfcView = null;
            }

            if (ProteinField != null) {
                ProteinField.Dispose ();
                ProteinField = null;
            }

            if (txtDesc != null) {
                txtDesc.Dispose ();
                txtDesc = null;
            }

            if (txtTitle != null) {
                txtTitle.Dispose ();
                txtTitle = null;
            }

            if (txtWeight != null) {
                txtWeight.Dispose ();
                txtWeight = null;
            }
        }
    }
}