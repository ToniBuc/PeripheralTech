using PeripheralTech.Mobile.ViewModels;
using PeripheralTech.Model;
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
    public partial class ProductVideoListPage : ContentPage
    {
        private ProductVideoListViewModel model = null;
        public ProductVideoListPage(int ? id)
        {
            InitializeComponent(); 
            BindingContext = model = new ProductVideoListViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ProductVideo;
            var id = item.ProductVideoID;
            //await Navigation.PushAsync(new ProductVideoPage(id));
            await Navigation.PushModalAsync(new NavigationPage(new ProductVideoPage(id)));
        }
    }
}