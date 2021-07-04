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
    public partial class CheckoutPage : ContentPage
    {
        private CheckoutViewModel model = null;
        private readonly APIService _productService = new APIService("Product");
        public CheckoutPage()
        {
            InitializeComponent();
            BindingContext = model = new CheckoutViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.OrderProductList.Count == 0)
            {
                orderProductListView.IsVisible = false;
                commentLabel.IsVisible = false;
                commentTextBox.IsVisible = false;
                totalPaymentLabel.IsVisible = false;
                purchaseButton.IsVisible = false;
                boxViewSeparator.IsVisible = false;
                mainLabel.Text = "Your Shopping Cart is Empty!";
            }
            else
            {
                orderProductListView.IsVisible = true;
                commentLabel.IsVisible = true;
                commentTextBox.IsVisible = true;
                totalPaymentLabel.IsVisible = true;
                purchaseButton.IsVisible = true;
                boxViewSeparator.IsVisible = true;
                mainLabel.Text = "Shopping Cart:";
            }
        }
        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int OrderProductID = Convert.ToInt32(button.CommandParameter);
            await model.Remove(OrderProductID);
            OnAppearing();
        }

        private async void purchaseButton_Clicked(object sender, EventArgs e)
        {
            bool stockChecker = false;
            foreach (var x in model.OrderProductList)
            {
                var product = await _productService.GetById<Model.Product>(x.ProductID);
                if (product.AmountInStock == 0)
                {
                    stockChecker = true;
                }
            }

            if (stockChecker == true)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "One or more product within your cart has gone out of stock before you could purchase it! " +
                                                                         "Please remove it from your cart if you wish to purchase the other products. " +
                                                                         "We apologise for the inconvenience.", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(APIService.User.Address) || !APIService.User.CityID.HasValue)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You must add both a City and Address (your residence to be delivered to) " +
                        "to your profile information before you can purchase products! If your resident city is not available in the options, please send in a request" +
                        "for it to be added through the app's question system.", "OK");
                }
                else
                {
                    var item = model.Order;
                    item.Comment = model.Comment;
                    await Navigation.PushAsync(new BillPaymentGatewayPage(item));
                }
            }
        }
    }
}