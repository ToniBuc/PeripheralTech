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
    public partial class ProductVideoPage : ContentPage
    {
        private ProductVideoViewModel model = null;
        public ProductVideoPage(int ? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductVideoViewModel()
            {
                ProductVideoID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}