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
    public partial class CustomMousePage : ContentPage
    {
        private CustomMouseViewModel model = null;
        public CustomMousePage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new CustomMouseViewModel()
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
                if (x.ProductTypeName == "Mouse Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
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
            }
            else
            {
                CasingListView.IsVisible = false;
            }
        }

        private void openCloseOrderButton_Clicked(object sender, EventArgs e)
        {
            if (CustomOrderCollectionView.IsVisible == false)
            {
                CustomOrderCollectionView.IsVisible = true;
                totalLabel.IsVisible = true;
                CasingListView.IsVisible = false;
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
            foreach (var x in model.CustomOrderList)
            {
                if (x.ProductTypeName == "Keyboard Casing")
                {
                    openCloseCasingsButton.IsEnabled = false;
                }
            }
        }
    }
}