using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Services;

namespace App2.ViewModels
{
    public class AppViewModelBase<T> : AppViewModelBase
    {
        private IRepository<T> _irepository;

        private IEnumerable<T> _collection;

        public AppViewModelBase(IRepository<T> iRepository, 
            INavigationService navigationService,
            IDialogService iDialogService):base(navigationService, iDialogService)
        {
            _irepository = iRepository;
           
        }

 

        protected IRepository<T> Repository { get { return _irepository; } }

       
    }

    public class AppViewModelBase : ViewModelBase
    {
        private IEnumerable _collection;
        private INavigationService _navigationService;
        private IDialogService _iDialogService;
        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { Set(ref _isLoading, value, broadcast: true); }
        }
        public  bool IsBusy { get; set; }
        public AppViewModelBase(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _iDialogService = dialogService;
        }
        public virtual void LoadData()
        {

           
        }

        public virtual object NavigationParameter { get; set; }

        public virtual IEnumerable Collection
        {
            get { return _collection; }
            protected set { Set(ref _collection, value); }
        }

        public INavigationService NavigationService { get { return _navigationService; } }

        public IDialogService DialogService { get { return _iDialogService; } }


        protected virtual async Task AttachLoading(params Task[] tasks)
        {
            try
            {
                this.IsLoading = true;
                await Task.WhenAll(tasks);
            }
            finally
            {
                this.IsLoading = false;
            }
        }

        protected virtual async Task AttachLoading(Func<Task> a)
        {
            try
            {
                this.IsLoading = true;
                await a();
            }
            catch (Exception ex)
            {
                //HandleException(ex);
            }
            finally
            {
                this.IsLoading = false;
            }
        }

        protected virtual async Task<T> AttachLoading<T>(Func<Task<T>> a)
        {
            try
            {
                this.IsLoading = true;
                return await a();
            }
            finally
            {
                this.IsLoading = false;
            }
        }
    }
}