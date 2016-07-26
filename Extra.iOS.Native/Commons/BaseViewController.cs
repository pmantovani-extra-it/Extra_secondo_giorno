using System;
using System.Collections.Generic;
using System.Text;
using App2.ViewModels;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace Extra.iOS.Native.Commons
{
    public class BaseViewController<T>: UIViewController where T : AppViewModelBase
    {
        public BaseViewController(IntPtr handle) : base (handle)
		{

        }
        public T ViewModel
        {
            get { return  Application.Locator.GetInstance<T>(); }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            ViewModel.NavigationParameter = ((NavigationService)Application.Locator.NavigationService).GetAndRemoveParameter(this);
            ViewModel.LoadData();
        }
    }
}
