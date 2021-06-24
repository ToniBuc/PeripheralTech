using PeripheralTech.Mobile.ViewModels;
using Rg.Plugins.Popup.Services;
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
    public partial class ProductImagesPage : ContentPage
    {
        private ProductImageViewModel model = null;
        public ProductImagesPage(int ? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductImageViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var x = (((TappedEventArgs)e).Parameter) as int?;
            //await PopupNavigation.PushAsync(new PictureImagePopupPage(x));
            await PopupNavigation.Instance.PushAsync(new PictureImagePopupPage(x));
        }
    }
}