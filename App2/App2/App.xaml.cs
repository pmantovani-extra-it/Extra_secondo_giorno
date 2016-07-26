using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {
        private ViewModelLocator _viewModelLocator;
        public App()
        {
            InitializeComponent();
            //inizilizzato il ViewModelLocator
            _viewModelLocator = new ViewModelLocator();
            //creato un istanza della NavigationService
            var navigationService = new NavigationService();
            var dialogService = new DialogService();
            //cofiguriamo il NavigationService
            navigationService.Configure(ViewModelLocator.DetailsViewModelKey, typeof(DetailsPage));
            //inizializiamo il ViewModelLocator
            _viewModelLocator.InitLocator(navigationService, dialogService);
            //creiamo un istanza della classe NavigationPage
            var navigationPage = new NavigationPage(new HomePage());
            dialogService.InitDialogService(navigationPage);
            //iniziailiziamo il NavigationService
            navigationService.Initialize(navigationPage);
            //impostiamo la prima pagina
            MainPage = navigationPage;
         


        }

        public ViewModelLocator ViewModelLocator
        {
            get { return _viewModelLocator; }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
