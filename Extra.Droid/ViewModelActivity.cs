using System.ComponentModel;
using Android.App;
using Android.OS;
using App2.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace Extra.Droid
{
    public class ViewModelActivity<T> : ActivityBase where T : AppViewModelBase
    {
        private ProgressDialog _progress;

        public T ViewModel
        {
            get { return ExtraContext.Locator.GetInstance<T>(); }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var parameter = ((NavigationService)ExtraContext.Locator.NavigationService).GetAndRemoveParameter(this.Intent);
            ViewModel.PropertyChanged += PropertyChanged;
            ViewModel.NavigationParameter = parameter;
            ViewModel.LoadData();
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AppViewModelBase.IsLoading))
            {
                LoadingChanged();
            }
        }

        private void LoadingChanged()
        {
            if (_progress == null)
            {
                _progress = new Android.App.ProgressDialog(this);
            }


            if (ViewModel.IsLoading)
            {
                _progress.Indeterminate = true;
                _progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                _progress.SetMessage("sto caricando...");
                _progress.SetCancelable(false);
                _progress.Show();
            }
            else
            {
                if (_progress == null) return;
                _progress.Hide();
            }
        }
    }
}