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
    public partial class OrderDetailsPage : ContentPage
    {
        private OrderDetailsViewModel model = null;
        private readonly APIService _productService = new APIService("Product");
        public OrderDetailsPage(int ? id)
        {
            InitializeComponent(); 
            BindingContext = model = new OrderDetailsViewModel()
            {
                OrderID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.Comment == null)
            {
                editorComment.IsVisible = false;
                labelComment.IsVisible = false;
            }
            if (!model.Order.OrderStatusName.Equals("Approved"))
            {
                payButton.IsVisible = false;
                payButton.IsEnabled = false;
            }
        }

        private async void reviewButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.CommandParameter);
            await Navigation.PushAsync(new ProductUserReviewPage(id));
            OnAppearing();
        }

        private async void payButton_Clicked(object sender, EventArgs e)
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
                await Application.Current.MainPage.DisplayAlert("Error", "One or more product within this custom order has gone out of stock before you could purchase it! " +
                                                                         "Please contact the staff through the existing or a new question to request an alternative or a restock. " +
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
                    List<Model.Product> list = new List<Model.Product>();
                    foreach (var x in model.OrderProductList)
                    {
                        var product = await _productService.GetById<Model.Product>(x.ProductID);
                        list.Add(product);
                    }

                    var item = model.Order;
                    //item.Comment = model.Comment;
                    await Navigation.PushAsync(new BillPaymentGatewayPage(item, list));
                }
            }
        }
    }
}