using PeripheralTech.Mobile.ViewModels;
using PeripheralTech.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeripheralTech.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQuestionPage : ContentPage
    {
        private NewQuestionViewModel model = null;
        public NewQuestionPage(ObservableCollection<Product> CustomOrderList = null, bool ? check = null)
        {
            InitializeComponent();
            BindingContext = model = new NewQuestionViewModel() 
            {
                //OrderID = id
                CustomOrderList = CustomOrderList,
                CustomOrderCheck = check
            };

            if (check != null)
            {
                cancelButton.IsEnabled = false;
                cancelButton.IsVisible = false;
            }
        }
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    //await model.Init();
        //}
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}