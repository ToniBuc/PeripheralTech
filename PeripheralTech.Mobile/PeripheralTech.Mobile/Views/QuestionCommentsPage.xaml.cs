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
    public partial class QuestionCommentsPage : ContentPage
    {
        private QuestionCommentsViewModel model = null;
        public QuestionCommentsPage(int ? id)
        {
            InitializeComponent();
            BindingContext = model = new QuestionCommentsViewModel()
            {
                QuestionID = id
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            if (model.Status == false)
            {
                replyButton.IsEnabled = false;
            }
        }
        private async void SendReply_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new QuestionNewCommentPage(model.QuestionID)));
        }
    }
}