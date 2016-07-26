using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using App2.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace Extra.Droid
{
    [Activity(Label = "Extra.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ViewModelActivity<HomeViewModel>
    {
     
   
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
     
            SetContentView(Resource.Layout.Main);
            ListView listView = FindViewById<ListView>(Resource.Id.Main_listView);
            listView.Adapter = new DataAdapterBase<PostItemViewModel>(ViewModel.Items, this, BindView, Resource.Layout.Cell_Post);
            listView.ItemClick += ListView_ItemClick;
        }

        private void BindView(PostItemViewModel item, View view)
        {
            TextView titleTextView = view.FindViewById<TextView>(Resource.Id.Main_Cell_Title);
            TextView subtleTextView = view.FindViewById<TextView>(Resource.Id.Main_Cell_SubTitle);
            titleTextView.Text = item.Title;
            subtleTextView.Text = item.Abstract;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var viewModel = ExtraContext.Locator.HomeViewModel;
           
            viewModel.NavigateToItemDetails(viewModel.Items[e.Position].InnertItem);
        }

        
    }

 
}

