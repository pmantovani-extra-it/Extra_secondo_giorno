using App2.ViewModels;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace Extra.iOS.Native
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = CreateLocator());
            }
        }

        private static ViewModelLocator CreateLocator()
        {
            var locator = new ViewModelLocator();
            var navigationService = new NavigationService();
            navigationService.Configure(ViewModelLocator.DetailsViewModelKey, "DetailsView");
            locator.InitLocator(navigationService, new DialogService());
            return locator;
        }

      
    }
}