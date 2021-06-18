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
    public partial class ProductsPage : ContentPage
    {
        private ProductsViewModel model = null;
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = model = new ProductsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            Logo.Source = ImageSource.FromFile("ptlogo.png");
        }

        private async void Filter_Clicked(object sender, EventArgs e)
        {
            await model.Init();
        }
    }
}