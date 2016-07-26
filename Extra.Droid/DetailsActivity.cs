using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.ViewModels;
using Services;

namespace Extra.Droid
{
    [Activity(Label = "DetailsActivity")]
    public class DetailsActivity : ViewModelActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);
            ListView gridView = FindViewById<ListView>(Resource.Id.Detail_GridView);
            gridView.Adapter = new DataAdapterBase<Comment>(ViewModel.Items, this, BindView, Resource.Layout.Cell_Post);
           
        }

        private void BindView(Comment item, View view)
        {
            var titleTextView = view.FindViewById<TextView>(Resource.Id.Main_Cell_Title);
            TextView subtleTextView = view.FindViewById<TextView>(Resource.Id.Main_Cell_SubTitle);
            titleTextView.Text = item.Name;
            subtleTextView.Text = item.Email;
        }

    }


}