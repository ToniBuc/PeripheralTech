using PeripheralTech.Mobile.ViewModels;
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
    public partial class QuestionsPage : ContentPage
    {
        private QuestionsViewModel model = null;
        public QuestionsPage()
        {
            InitializeComponent();
            BindingContext = model = new QuestionsViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Question;
            var id = item.QuestionID;
            await Navigation.PushAsync(new QuestionCommentsPage(id));
        }
        private async void NewQuestion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewQuestionPage()));
        }
    }
}