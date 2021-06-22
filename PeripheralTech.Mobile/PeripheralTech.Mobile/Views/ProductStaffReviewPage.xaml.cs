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
    public partial class ProductStaffReviewPage : ContentPage
    {
        private ProductStaffReviewViewModel model = null;
        public ProductStaffReviewPage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductStaffReviewViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (Math.Round(model.Rating) == 1)
            {
                ratingImage.Source = ImageSource.FromFile("rating1.png");
            }
            else if (Math.Round(model.Rating) == 2)
            {
                ratingImage.Source = ImageSource.FromFile("rating2.png");
            }
            else if (Math.Round(model.Rating) == 3)
            {
                ratingImage.Source = ImageSource.FromFile("rating3.png");
            }
            else if (Math.Round(model.Rating) == 4)
            {
                ratingImage.Source = ImageSource.FromFile("rating4.png");
            }
            else if (Math.Round(model.Rating) == 5)
            {
                ratingImage.Source = ImageSource.FromFile("rating5.png");
            }
        }
    }
}