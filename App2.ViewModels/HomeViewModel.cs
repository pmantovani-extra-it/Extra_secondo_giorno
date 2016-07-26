using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using App2.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Services;

namespace App2.ViewModels
{
    public class HomeViewModel : AppViewModelBase<Post>
    {

        private ObservableCollectionEx<PostItemViewModel> _items;
        private ItemViewModel<Post> _selectedPost;
        private bool _isLoading;

        public HomeViewModel(IRepository<Post> iRepository, INavigationService navigationService, IDialogService dialogService) :
            base(iRepository, navigationService, dialogService)
        {

            NavigateCommand = new RelayCommand(
                () => 
                DialogService.ShowMessage("titolo", "messaggio")
                );
         
           
        }

        public override IEnumerable Collection
        {
            get { return Items; }
            protected  set {}
        }

        public void Navigate()
        {
            NavigationService.NavigateTo(ViewModelLocator.DetailsViewModelKey, new Post { Id = 1 });
           
        }
        public RelayCommand NavigateCommand { get; private set; }
        public int ItemsCount
        {
            get { return Items.Count; }
        }
        public ObservableCollectionEx<PostItemViewModel> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ObservableCollectionEx<PostItemViewModel>();
                }
                return _items;
            }
            set
            {
                
                Set(ref _items, value);
                RaisePropertyChanged("Collection");
            }
        }
        public override async void LoadData()
        {
          
            Items.Clear();
            var items = await this.AttachLoading(() => Repository.GetItemsAsync());
            Items.AddRange(items.Select(e => new PostItemViewModel(e, this)));
           
        }

        public ItemViewModel<Post> SelectedPostItem
        {

            get { return _selectedPost; }
            set
            {
                Set(ref _selectedPost, value);
                NavigateToItemDetails(SelectedPostItem.InnertItem);
            }
        }

       

        public void NavigateToItemDetails(Post post)
        {
            NavigationService.NavigateTo(ViewModelLocator.DetailsViewModelKey, post);
        }
        public async void DeletePost(PostItemViewModel postItemViewModel)
        {
            if(await  DialogService.ShowMessage("Vuoi cancellare l'elemento","Attezione!!", "ok", "cancel", null))
            Items.Remove(postItemViewModel);
        }
    }
}
