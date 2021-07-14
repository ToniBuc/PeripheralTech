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
    public partial class CustomKeyboardPage : ContentPage
    {
        private CustomKeyboardViewModel model = null;
        public CustomKeyboardPage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new CustomKeyboardViewModel()
            {
                ProductID = id
            };
            CustomOrderCollectionView.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            mainLabel.Text = "Custom " + model.Product.Name + " Order";

            CasingListView.IsVisible = false;
            KeycapListView.IsVisible = false;
            SoundDampenerListView.IsVisible = false;
            if (model.CustomOrderList.Count > 1)
            {
                orderButton.IsEnabled = true;
            }
            else
            {
                orderButton.IsEnabled = false;
            }
        }
        private async void PickButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int ProductID = Convert.ToInt32(button.CommandParameter);
            await model.PickProduct(ProductID);
            OnAppearing();
            foreach (var x in model.CustomOrderList)
            {
                if (x.ProductTypeName == "Keyboard Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Keycaps")
                {
                    openCloseKeycapsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Keyboard Sound Dampeners")
                {
                    openCloseSoundDampenersButton.IsEnabled = false;
                }
            }
        }

        private void openCloseCasingsButton_Clicked(object sender, EventArgs e)
        {
            if (CasingListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = true;
                KeycapListView.IsVisible = false;
                SoundDampenerListView.IsVisible = false;
            }
            else
            {
                CasingListView.IsVisible = false;
            }
        }

        private void openCloseKeycapsButton_Clicked(object sender, EventArgs e)
        {
            if (KeycapListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = false;
                KeycapListView.IsVisible = true;
                SoundDampenerListView.IsVisible = false;
            }
            else
            {
                KeycapListView.IsVisible = false;
            }
        }

        private void openCloseSoundDampenersButton_Clicked(object sender, EventArgs e)
        {
            if (SoundDampenerListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = false;
                KeycapListView.IsVisible = false;
                SoundDampenerListView.IsVisible = true;
            }
            else
            {
                SoundDampenerListView.IsVisible = false;
            }
        }

        private void openCloseOrderButton_Clicked(object sender, EventArgs e)
        {
            if (CustomOrderCollectionView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = true;
                totalLabel.IsVisible = true;
                CasingListView.IsVisible = false;
                KeycapListView.IsVisible = false;
                SoundDampenerListView.IsVisible = false;
            }
            else
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
            }
        }

        private async void removeButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int ProductID = Convert.ToInt32(button.CommandParameter);
            await model.RemoveProduct(ProductID);
            OnAppearing();
            openCloseCasingsButton.IsEnabled = true;
            openCloseKeycapsButton.IsEnabled = true;
            openCloseSoundDampenersButton.IsEnabled = true;
            foreach (var x in model.CustomOrderList)
            {
                if (x.ProductTypeName == "Keyboard Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Keycaps")
                {
                    openCloseKeycapsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Keyboard Sound Dampeners")
                {
                    openCloseSoundDampenersButton.IsEnabled = false;
                }
            }
        }
    }
}