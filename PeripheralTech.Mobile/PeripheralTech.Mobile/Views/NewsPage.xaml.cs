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
    public partial class NewsPage : ContentPage
    {
        private NewsViewModel model = null;
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = model = new NewsViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var x = (((TappedEventArgs)e).Parameter) as int?;
            await Navigation.PushAsync(new NewsArticlePage(x));
        }
    }
}