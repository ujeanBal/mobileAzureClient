using System;
using FoodAppClient.iOS.ViewModel;
using FoodAppClient.Models;
using FoodAppClient.Services;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace FoodAppClient
{
    public class App
    {
        public static string BackendUrl = "http://10.130.12.104:88";
        private static ViewModelLocator locator;
        public static ViewModelLocator Locator => locator ?? (locator = new ViewModelLocator());

        public static void Initialize()
        {
           
        }
    }
}
