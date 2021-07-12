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
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            mainLabel.Text = "Custom " + model.Product.Name + " Order";
            //if (model.CustomOrderList.Count == 0)
            //{
            //    CustomOrderCollectionView.IsVisible = false;
            //    boxViewSeparator2.IsVisible = false;
            //}
            //else
            //{
            //    CustomOrderCollectionView.IsVisible = true;
            //    boxViewSeparator2.IsVisible = true;
            //}
            CustomOrderCollectionView.IsVisible = false;
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
        }

        private void openCloseCasingsButton_Clicked(object sender, EventArgs e)
        {
            if (CasingListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                CasingListView.IsVisible = true;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
                openCloseCasingsButton.Text = "Close";
                openCloseButtonKitsButton.Text = "Open";
                openCloseThumbsticksButton.Text = "Open";
                openClosePaddlesButton.Text = "Open";
                openCloseOrderButton.Text = "Open";
            }
            else
            {
                CasingListView.IsVisible = false;
                openCloseCasingsButton.Text = "Open";
            }
        }

        private void openCloseButtonKitsButton_Clicked(object sender, EventArgs e)
        {
            if (ButtonKitListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = true;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
                openCloseButtonKitsButton.Text = "Close";
                openCloseCasingsButton.Text = "Open";
                openCloseThumbsticksButton.Text = "Open";
                openClosePaddlesButton.Text = "Open";
                openCloseOrderButton.Text = "Open";
            }
            else
            {
                ButtonKitListView.IsVisible = false;
                openCloseButtonKitsButton.Text = "Open";
            }
        }

        private void openCloseThumbsticksButton_Clicked(object sender, EventArgs e)
        {
            if (ThumbstickListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = true;
                PaddlesListView.IsVisible = false;
                openCloseThumbsticksButton.Text = "Close";
                openCloseButtonKitsButton.Text = "Open";
                openCloseCasingsButton.Text = "Open";
                openClosePaddlesButton.Text = "Open";
                openCloseOrderButton.Text = "Open";
            }
            else
            {
                ThumbstickListView.IsVisible = false;
                openCloseThumbsticksButton.Text = "Open";
            }
        }

        private void openClosePaddlesButton_Clicked(object sender, EventArgs e)
        {
            if (PaddlesListView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = false;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = true;
                openClosePaddlesButton.Text = "Close";
                openCloseThumbsticksButton.Text = "Open";
                openCloseButtonKitsButton.Text = "Open";
                openCloseCasingsButton.Text = "Open";
                openCloseOrderButton.Text = "Open";
            }
            else
            {
                PaddlesListView.IsVisible = false;
                openClosePaddlesButton.Text = "Open";
            }
        }

        private void openCloseOrderButton_Clicked(object sender, EventArgs e)
        {
            if (CustomOrderCollectionView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = true;
                CasingListView.IsVisible = false;
                ButtonKitListView.IsVisible = false;
                ThumbstickListView.IsVisible = false;
                PaddlesListView.IsVisible = false;
                openCloseOrderButton.Text = "Close";
                openClosePaddlesButton.Text = "Open";
                openCloseThumbsticksButton.Text = "Open";
                openCloseButtonKitsButton.Text = "Open";
                openCloseCasingsButton.Text = "Open";
            }
            else
            {
                CustomOrderCollectionView.IsVisible = false;
                openCloseOrderButton.Text = "Open";
            }
        }
        //private async void PickCasingButton_Clicked(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int ProductID = Convert.ToInt32(button.CommandParameter);
        //    await model.PickProduct(ProductID);
        //    OnAppearing();
        //}
        //private async void PickButtonKitButton_Clicked(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int ProductID = Convert.ToInt32(button.CommandParameter);
        //    await model.PickProduct(ProductID);
        //    OnAppearing();
        //}
        //private async void PickThumbsticksButton_Clicked(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int ProductID = Convert.ToInt32(button.CommandParameter);
        //    await model.PickProduct(ProductID);
        //    OnAppearing();
        //}
        //private async void PickPaddlesButton_Clicked(object sender, EventArgs e)
        //{
        //    Button button = (Button)sender;
        //    int ProductID = Convert.ToInt32(button.CommandParameter);
        //    await model.PickProduct(ProductID);
        //    OnAppearing();
        //}
    }
}