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
    public partial class CheckoutPage : ContentPage
    {
        private CheckoutViewModel model = null;
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
            }
            else
            {
                emptyLabel.IsVisible = false;
            }
        }
        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int OrderProductID = Convert.ToInt32(button.CommandParameter);
            await model.Remove(OrderProductID);
        }

        private async void purchaseButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(APIService.User.Address) || !APIService.User.CityID.HasValue)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must add a City and Address (your residence to be delivered to) to your profile information before you can purchase products!", "OK");
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