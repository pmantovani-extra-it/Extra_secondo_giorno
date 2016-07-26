using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Services;

namespace App2.ViewModels
{
    public class DetailsViewModel: AppViewModelBase<Comment>
    {
        
       
        private ObservableCollectionEx<Comment> _items;
        private object _navigationParameter;

        public DetailsViewModel(IRepository<Comment> iRepository,
           INavigationService navigationService,
           IDialogService iDialogService):base(iRepository, navigationService, iDialogService)
        {
           

        }

        public override object NavigationParameter
        {
            get { return _navigationParameter; }
            set
            {
                _navigationParameter = value;
                CurrentPost = _navigationParameter as Post;
            }
        }

        public ObservableCollectionEx<Comment> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollectionEx<Comment>();
                }
                return _items;
            }
            set { Set(ref _items, value); }
        }
        public Post CurrentPost { get; set; }

        public override async void LoadData()
        {
            Items.Clear();
           Items.AddRange(await this.AttachLoading(()=> Repository.GetItemsAsync(CurrentPost.Id)));
        }
    }
}
