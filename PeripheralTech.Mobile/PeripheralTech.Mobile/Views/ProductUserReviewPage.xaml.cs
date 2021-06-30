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
    public partial class ProductUserReviewPage : ContentPage
    {
        private ProductUserReviewViewModel model = null;
        public ProductUserReviewPage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductUserReviewViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            pickerRating.SelectedIndex = model.Rating - 1;
        }
    }
}