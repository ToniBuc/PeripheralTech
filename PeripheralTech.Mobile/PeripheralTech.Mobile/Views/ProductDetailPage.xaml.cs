﻿using PeripheralTech.Mobile.ViewModels;
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
        }
    }
}