﻿using PeripheralTech.Mobile.ViewModels;
using PeripheralTech.Model;
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
    public partial class CustomOrderPage : ContentPage
    {
        private CustomOrderListViewModel model = null;
        public CustomOrderPage()
        {
            InitializeComponent();
            BindingContext = model = new CustomOrderListViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Product;
            var id = item.ProductID;
            if (item.ProductTypeName == "Controller")
            {
                await Navigation.PushAsync(new CustomControllerPage(id));
            }
            
        }
    }
}