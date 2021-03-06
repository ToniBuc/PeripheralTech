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
    public partial class QuestionNewCommentPage : ContentPage
    {
        private QuestionNewCommentViewModel model = null;
        public QuestionNewCommentPage(int? id)
        {
            InitializeComponent();
            BindingContext = model = new QuestionNewCommentViewModel()
            {
                QuestionID = id
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void CancelReply_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}