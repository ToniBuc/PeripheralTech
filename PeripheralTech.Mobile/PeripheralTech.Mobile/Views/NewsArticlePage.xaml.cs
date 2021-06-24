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
    public partial class NewsArticlePage : ContentPage
    {
        private NewsArticleViewModel model = null;
        public NewsArticlePage(int ? id )
        {
            InitializeComponent();
            BindingContext = model = new NewsArticleViewModel()
            {
                NewsID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();

            if (!(model.News.Thumbnail.Length > 0))
            {
                imageStackLayout.IsVisible = false;
            }
        }
    }
}