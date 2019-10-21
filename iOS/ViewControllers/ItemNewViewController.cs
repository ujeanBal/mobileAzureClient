using System;
using System.Collections.Generic;
using FoodAppClient.iOS.Helpers;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

using UIKit;

namespace FoodAppClient.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        private FoodDetailViewModel viewModel { get; set; }

        private IList<Binding> _bindings;

        private UIImagePickerController _imagePicker;

        private readonly ImageStringConverter _imageStringConverter;

        public ItemNewViewController(IntPtr handle) : this(SimpleIoc.Default.GetInstance<ImageStringConverter>(), handle)
        {
        }

        public ItemNewViewController(ImageStringConverter converter, IntPtr handle) : base(handle)
        {
            _imageStringConverter = converter;
            _bindings = new List<Binding>();
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            viewModel = InitParammeter();

            btnSaveItem.SetTitle(viewModel.ActionTitle, UIControlState.Normal);

            _bindings.Add(this.SetBinding(() => viewModel.Item.Name, () => txtTitle.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Kkal, () => txtDesc.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Weight, () => txtWeight.Text, BindingMode.TwoWay));

            _bindings.Add(this.SetBinding(() => viewModel.Item.Proteins, () => ProteinField.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Fats, () => FatsField.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Carbohydrates, () => CarboField.Text, BindingMode.TwoWay));
            _bindings.Add(this.SetBinding(() => viewModel.Item.Image, () => imageView.Image, BindingMode.TwoWay).ConvertSourceToTarget((bytesString) =>
            {
                return String.IsNullOrEmpty(bytesString) ? UIImage.FromBundle("nofile.jpeg") : _imageStringConverter.ConvertToUIImage(bytesString);
            }));

            btnSaveItem.SetCommand("TouchUpInside", viewModel.SendToMainCommand, this.SetBinding(() => viewModel.Item));
            btnSaveItem.SetCommand("TouchUpInside", new RelayCommand(() => { NavigationController?.PopToRootViewController(true); }));
            btnChooseImg.SetCommand("TouchUpInside", new RelayCommand(() => { CallPopupForChooseImage(); }));
        }

        private void CallPopupForChooseImage()
        {
            _imagePicker = new UIImagePickerController();

            // set our source to the photo library
            _imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

            // set what media types
            _imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

            _imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
            //Eventhandler cannot convert to EventHandler
            //imagePicker.SetCommand("FinishedPickingMedia", new RelayCommand<EventArgs>(Handle_FinishedPickingMedia));

            _imagePicker.SetCommand("Canceled", new RelayCommand(() => { Handle_Canceled(); }));

            NavigationController.PresentModalViewController(_imagePicker, true);
        }

        void Handle_Canceled()
        {
            _imagePicker.DismissModalViewController(true);
        }

        protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {

            bool isImage = false;
            switch (args.Info[UIImagePickerController.MediaType].ToString())
            {
                case "public.image":
                    Console.WriteLine("Image selected");
                    isImage = true;
                    break;

                case "public.video":
                    Console.WriteLine("Video selected");
                    break;
            }

            if (isImage)
            {

                UIImage originalImage = args.Info[UIImagePickerController.OriginalImage] as UIImage;
                if (originalImage != null)
                {
                    viewModel.Item.Image = _imageStringConverter.ConvertToSrtring(originalImage);
                    imageView.Layer.CornerRadius = 30;
                    imageView.Layer.MasksToBounds = true;
                }
            }

            _imagePicker.DismissModalViewController(true);
        }

        private FoodDetailViewModel InitParammeter()
        {
            var nav = (NavigationService)SimpleIoc.Default.GetInstance<INavigationService>();
            UIViewController controller = nav.NavigationController.TopViewController; //The UIKit.UIViewController that was navigated to
            return (FoodDetailViewModel)nav.GetAndRemoveParameter(controller);
        }
    }
}
