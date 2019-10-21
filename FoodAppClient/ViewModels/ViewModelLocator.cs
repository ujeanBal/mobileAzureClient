using FoodAppClient.Models;
using FoodAppClient.Services;
using FoodAppClient.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace FoodAppClient.iOS.ViewModel
{
    public class ViewModelLocator
    {
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

        public string Details => "ItemNewViewController";

        public string NewFood => "ItemNewViewController";


        public static void Cleanup()
        {
            
        }
    }
}