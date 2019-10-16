/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FoodAppClient.iOS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using FoodAppClient.Models;
using FoodAppClient.Services;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace FoodAppClient.iOS.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {

            SimpleIoc.Default.Register<IDataStore<Food>, CloudFoodService>();
            SimpleIoc.Default.Register<ItemsViewModel>();
            SimpleIoc.Default.Register<FoodDetailViewModel>();
        }

        public ItemsViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ItemsViewModel>();
            }
        }

        public string Details => "BrowseItemDetailViewController";

        public string NewFood => "ItemNewViewController";


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}