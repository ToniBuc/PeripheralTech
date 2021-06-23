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
    public partial class ProductUserReviewsPage : ContentPage
    {
        private ProductUserReviewsViewModel model = null;
        public ProductUserReviewsPage(int ? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductUserReviewsViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}