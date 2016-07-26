using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace App2.ViewModels
{

    public class ItemViewModel<T>: ViewModelBase
    {
        protected T _item;
        public ItemViewModel(T item)
        {
            _item = item;
        }

        public T InnertItem
        {
            get { return _item; }
        }

    }

    public class PostItemViewModel : ItemViewModel<Post>
    {
        private HomeViewModel _parent;
        public PostItemViewModel(Post post, HomeViewModel homeViewModel):base(post)
        {
            DeleteCommand = new RelayCommand(Delete);
            _parent = homeViewModel;
        }

        private void Delete()
        {
            _parent.DeletePost(this);
        }

        public string Title
        {
            get { return _item.Title; }
            set
            {
                InnertItem.Title = value;
                RaisePropertyChanged();
            }
        }

      
        public string Abstract
        {
            get { return Body.Substring(0, 50); }
        }
        public string Body
        {
            get { return InnertItem.Body; }
            set
            {
                InnertItem.Body = value;
                RaisePropertyChanged();
            }
        }

        public  RelayCommand DeleteCommand { get; private set; }
    }
}
