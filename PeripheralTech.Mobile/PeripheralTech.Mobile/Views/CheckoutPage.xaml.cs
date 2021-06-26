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
        }
        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int OrderProductID = Convert.ToInt32(button.CommandParameter);
            await model.Remove(OrderProductID);
        }
    }
}