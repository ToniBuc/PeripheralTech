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
    public partial class ProfilePage : ContentPage
    {
        private ProfileViewModel model = null;
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = model = new ProfileViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (profileImage.Source == null)
            {
                profileImage.Source = ImageSource.FromFile("ptlogo.png");
            }
        }
    }
}