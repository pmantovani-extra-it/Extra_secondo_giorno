using App2.Models;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Services;

namespace App2.ViewModels
{
    public class ViewModelLocator
    {
        public const string HomeViewModelKey = nameof(HomeViewModel);
        public const string DetailsViewModelKey = nameof(DetailsViewModel);
        public void InitLocator(INavigationService navigationService, IDialogService dialogService)
        {
            ServiceLocator.SetLocatorProvider(()=> SimpleIoc.Default);
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<DetailsViewModel>();
            SimpleIoc.Default.Register(()=> navigationService);
            SimpleIoc.Default.Register(()=> dialogService);
            SimpleIoc.Default.Register<IRepository<Post>, RestPostRepository>();
            SimpleIoc.Default.Register<IRepository<Comment>, CommentRepository>();
           
        }

        public  T GetInstance<T>()
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
        public HomeViewModel HomeViewModel
        {
            get { return ServiceLocator.Current.GetInstance<HomeViewModel>(); }
        }

        public DetailsViewModel DetailsViewModel
        {

            get { return ServiceLocator.Current.GetInstance <DetailsViewModel>(); }
        }

        public INavigationService NavigationService
        {
            get { return ServiceLocator.Current.GetInstance<INavigationService>(); }
        }

    }
}