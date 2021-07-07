using PeripheralTech.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeripheralTech.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private ProductDetailViewModel model = null;
        public ProductDetailPage(int ? id)
        {
            InitializeComponent();
            BindingContext = model = new ProductDetailViewModel()
            {
                ProductID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.Rating == 0)
            {
                labelProc.IsVisible = true;
            }
            else if (Math.Round(model.Rating) == 1)
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

            if (model.UserReviewList.Count == 0)
            {
                reviewsButton.IsEnabled = false;
            }
            if (model.StaffReview.Count == 0)
            {
                staffReviewButton.IsEnabled = false;
            }

            //if (model.OrderProduct.Count == 1)
            //{
            //    if (model.OrderProduct[0].ProductID == model.ProductID)
            //    {
            //        addToCartButton.IsEnabled = false;
            //        addToCartButton.Text = "In Cart";
            //    }
            //}
            if (Convert.ToInt32(model.AmountInStock) == 0)
            {
                addToCartButton.IsEnabled = false;
                addToCartButton.Text = "Out of Stock";
            }
        }

        private async void UserReviews_Clicked(object sender, EventArgs e)
        {
            var id = model.ProductID;
            await Navigation.PushAsync(new ProductUserReviewsPage(id));
        }

        private async void StaffReview_Clicked(object sender, EventArgs e)
        {
            var id = model.ProductID;
            await Navigation.PushAsync(new ProductStaffReviewPage(id));
        }
        private async void ProductImages_Clicked(object sender, EventArgs e)
        {
            var id = model.ProductID;
            await Navigation.PushAsync(new ProductImagesPage(id));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var x = (((TappedEventArgs)e).Parameter) as int?;
            await Navigation.PushAsync(new ProductDetailPage(x));
        }

        private async void productVideos_Clicked(object sender, EventArgs e)
        {
            var id = model.ProductID;
            await Navigation.PushAsync(new ProductVideoListPage(id));
        }
    }
}