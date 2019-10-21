using Foundation;
using UIKit;

using GalaSoft.MvvmLight.Views;

using CoreGraphics;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;

namespace FoodAppClient.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            DispatcherHelper.Initialize(application);
            App.Initialize();

            var nav = new NavigationService();

            nav.Configure(App.Locator.Details, App.Locator.Details);
            nav.Initialize((UINavigationController)Window.RootViewController);

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            return true;
        }



    }
}
