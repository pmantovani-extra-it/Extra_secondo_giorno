using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App2.ViewModels;
using Services;
using Xamarin.Forms;

namespace App2
{

    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = ((App)Application.Current).ViewModelLocator.HomeViewModel;
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await this.DisplayAlert("jskjdkdjks", "jkjfksjfks","cancella");
        }
    }
}
