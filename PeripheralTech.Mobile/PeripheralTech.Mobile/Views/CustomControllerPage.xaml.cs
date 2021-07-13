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

            //CustomOrderCollectionView.IsVisible = false;
            CasingListView.IsVisible = false;
            ButtonKitListView.IsVisible = false;
            ThumbstickListView.IsVisible = false;
            PaddlesListView.IsVisible = false;
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
                //openCloseCasingsButton.Text = "Close";
                //openCloseButtonKitsButton.Text = "Open";
                //openCloseThumbsticksButton.Text = "Open";
                //openClosePaddlesButton.Text = "Open";
                //openCloseOrderButton.Text = "Open";
            }
            else
            {
                CasingListView.IsVisible = false;
                //openCloseCasingsButton.Text = "Open";
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
                //openCloseButtonKitsButton.Text = "Close";
                //openCloseCasingsButton.Text = "Open";
                //openCloseThumbsticksButton.Text = "Open";
                //openClosePaddlesButton.Text = "Open";
                //openCloseOrderButton.Text = "Open";
            }
            else
            {
                ButtonKitListView.IsVisible = false;
                //openCloseButtonKitsButton.Text = "Open";
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
                //openCloseThumbsticksButton.Text = "Close";
                //openCloseButtonKitsButton.Text = "Open";
                //openCloseCasingsButton.Text = "Open";
                //openClosePaddlesButton.Text = "Open";
                //openCloseOrderButton.Text = "Open";
            }
            else
            {
                ThumbstickListView.IsVisible = false;
                //openCloseThumbsticksButton.Text = "Open";
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
                //openClosePaddlesButton.Text = "Close";
                //openCloseThumbsticksButton.Text = "Open";
                //openCloseButtonKitsButton.Text = "Open";
                //openCloseCasingsButton.Text = "Open";
                //openCloseOrderButton.Text = "Open";
            }
            else
            {
                PaddlesListView.IsVisible = false;
                //openClosePaddlesButton.Text = "Open";
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
                //openCloseOrderButton.Text = "Close";
                //openClosePaddlesButton.Text = "Open";
                //openCloseThumbsticksButton.Text = "Open";
                //openCloseButtonKitsButton.Text = "Open";
                //openCloseCasingsButton.Text = "Open";
            }
            else
            {
                CustomOrderCollectionView.IsVisible = false;
                totalLabel.IsVisible = false;
                //openCloseOrderButton.Text = "Open";
            }
        }

        private async void removeButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int ProductID = Convert.ToInt32(button.CommandParameter);
            await model.RemoveProduct(ProductID);
            OnAppearing();
            //openCloseOrderButton.Text = "Open";
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