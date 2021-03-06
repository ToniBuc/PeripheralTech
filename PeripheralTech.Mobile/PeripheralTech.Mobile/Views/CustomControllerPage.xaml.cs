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
    public partial class CustomControllerPage : ContentPage
    {
        private CustomControllerViewModel model = null;
        public CustomControllerPage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new CustomControllerViewModel()
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
            ButtonKitListView.IsVisible = false;
            ThumbstickListView.IsVisible = false;
            PaddlesListView.IsVisible = false;
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
            foreach(var x in model.CustomOrderList)
            {
                if (x.ProductTypeName == "Controller Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Button Kit")
                {
                    openCloseButtonKitsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Thumbsticks")
                {
                    openCloseThumbsticksButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Paddles")
                {
                    openClosePaddlesButton.IsEnabled = false;
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
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
            }
            else
            {
                CasingListView.IsVisible = false;
            }
        }

        private void openCloseButtonKitsButton_Clicked(object sender, EventArgs e)
        {
            if (ButtonKitListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = true;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
            }
            else
            {
                ButtonKitListView.IsVisible = false;
            }
        }

        private void openCloseThumbsticksButton_Clicked(object sender, EventArgs e)
        {
            if (ThumbstickListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = true;
                PaddlesListView.IsVisible = false;
            }
            else
            {
                ThumbstickListView.IsVisible = false;
            }
        }

        private void openClosePaddlesButton_Clicked(object sender, EventArgs e)
        {
            if (PaddlesListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false; 
                totalLabel.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = true;
            }
            else
            {
                PaddlesListView.IsVisible = false;
            }
        }

        private void openCloseOrderButton_Clicked(object sender, EventArgs e)
        {
            if (CustomOrderCollectionView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = true;
                totalLabel.IsVisible = true;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
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
            openCloseButtonKitsButton.IsEnabled = true;
            openCloseThumbsticksButton.IsEnabled = true;
            openClosePaddlesButton.IsEnabled = true;
            foreach (var x in model.CustomOrderList)
            {
                if (x.ProductTypeName == "Controller Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Button Kit")
                {
                    openCloseButtonKitsButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Thumbsticks")
                {
                    openCloseThumbsticksButton.IsEnabled = false;
                }
                else if (x.ProductTypeName == "Controller Paddles")
                {
                    openClosePaddlesButton.IsEnabled = false;
                }
            }
        }
    }
}