using System;
using System.Collections.Generic;
using FoodAppClient.Models;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace FoodAppClient.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        private FoodDetailViewModel viewModel { get; set; }

        IList<Binding> _bindings = new List<Binding>();

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = InitParammeter();
            _bindings.Add(this.SetBinding(() => viewModel.Item.Name, () => txtTitle.Text,BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Name, () => bind.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Kkal, () => txtDesc.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Weight, () => txtWeight.Text, BindingMode.TwoWay));

            _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Proteins, () => ProteinField.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Fats, () => FatsField.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Description.Carbohydrates, () => CarboField.Text,BindingMode.TwoWay));

            btnSaveItem.SetCommand("TouchUpInside", viewModel.SendToMainCommand, this.SetBinding(() => viewModel.Item));
        }

        private FoodDetailViewModel InitParammeter()
        {
            var nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            UIViewController controller = nav.NavigationController.TopViewController; //The UIKit.UIViewController that was navigated to
            return (FoodDetailViewModel)nav.GetAndRemoveParameter(controller);
        }
    }
}
