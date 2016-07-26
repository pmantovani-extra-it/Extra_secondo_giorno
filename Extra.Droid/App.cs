using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace Extra.Droid
{
    public  static class ExtraContext
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                    InitLocator();

                return _locator;
            }
        }

        private static void InitLocator()
        {
            _locator = new ViewModelLocator();
            var nav = new NavigationService();
            nav.Configure(ViewModelLocator.DetailsViewModelKey, typeof(DetailsActivity));
            _locator.InitLocator(nav, new DialogService());
        }
    }
}