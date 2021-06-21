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
    public partial class NewQuestionPage : ContentPage
    {
        private NewQuestionViewModel model = null;
        public NewQuestionPage()
        {
            InitializeComponent();
            BindingContext = model = new NewQuestionViewModel();
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