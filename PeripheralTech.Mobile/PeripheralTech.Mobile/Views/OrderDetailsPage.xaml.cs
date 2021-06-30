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
        }

        private async void reviewButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.CommandParameter);
            await Navigation.PushAsync(new ProductUserReviewPage(id));
            OnAppearing();
        }
    }
}