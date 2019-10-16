using System;
using System.Collections.Generic;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace FoodAppClient.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        private FoodDetailViewModel viewModel { get; set; }

        IList<Binding> _bindings = new List<Binding>();

        public BrowseItemDetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = InitParammeter();

            _bindings.Add(this.SetBinding(() => viewModel.Title, () => Title));
            _bindings.Add(this.SetBinding(() => viewModel.Title, () => ItemNameLabel.Text));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Weight, () => WeightVal.Text));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Kkal, () => KkalVal.Text));

            if (viewModel.Item.Description != null)
            {
                _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Proteins, () => ProteinsVal.Text));
                _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Fats, () => FatsVal.Text));
                _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Carbohydrates, () => CarboFats.Text));
            }
        }

        private FoodDetailViewModel InitParammeter()
        {
            var nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            UIViewController controller = nav.NavigationController.TopViewController; //The UIKit.UIViewController that was navigated to
            return (FoodDetailViewModel)nav.GetAndRemoveParameter(controller);
        }
    }
}
