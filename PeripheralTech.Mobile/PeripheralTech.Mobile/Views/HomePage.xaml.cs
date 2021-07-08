using PeripheralTech.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeripheralTech.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel model = null;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = model = new HomeViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            Logo.Source = ImageSource.FromFile("ptlogo.png");
        }

        private async void TapGestureRecognizerRecent_Tapped(object sender, EventArgs e)
        {
            var x = (((TappedEventArgs)e).Parameter) as int?;
            await Navigation.PushAsync(new ProductDetailPage(x));
        }
        private async void TapGestureRecognizerDiscount_Tapped(object sender, EventArgs e)
        {
            var x = (((TappedEventArgs)e).Parameter) as int?;
            await Navigation.PushAsync(new ProductDetailPage(x));
        }
    }
}