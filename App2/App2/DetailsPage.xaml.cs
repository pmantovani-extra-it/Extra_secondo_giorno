using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using App2.ViewModels;
using Xamarin.Forms;

namespace App2
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Post post)
        {
            InitializeComponent();
            var viewModel = ((App)Application.Current).ViewModelLocator.DetailsViewModel;
            viewModel.CurrentPost = post;
            viewModel.LoadData();
            BindingContext = viewModel;
        }
        
    }
}
