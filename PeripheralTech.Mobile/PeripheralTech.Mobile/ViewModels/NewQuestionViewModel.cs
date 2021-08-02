using PeripheralTech.Mobile.Views;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class NewQuestionViewModel : BaseViewModel
    {
        private readonly APIService _questionService = new APIService("Question");
        public int? OrderID { get; set; }
        public NewQuestionViewModel()
        {
            //InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Submit());
        }
        //public ICommand InitCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        #region Initialization
        private string _questionTitle = string.Empty;
        public string QuestionTitle
        {
            get { return _questionTitle; }
            set { SetProperty(ref _questionTitle, value); }
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
        #endregion

        //public async Task Init()
        //{
        //    var question = await _questionService.GetById<Question>(QuestionID);
        //    QuestionTitle = question.Title;
        //}
        public async Task Submit()
        {
            var request = new QuestionInsertRequest()
            {
                CustomerID = APIService.UserID,
                Date = DateTime.Now,
                Title = QuestionTitle,
                Content = Content,
                Status = true
            };

            if (OrderID != null)
            {
                request.OrderID = OrderID;
            }

            if (string.IsNullOrWhiteSpace(Content) || string.IsNullOrWhiteSpace(QuestionTitle))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Both the Title and Content fields can not be empty, please fill them in before attempting to send the question in!", "OK");
            }
            else
            {
                await _questionService.Insert<Model.Question>(request);
                await Application.Current.MainPage.DisplayAlert("Notification", "Your question has been successfully sent!", "OK");
                if (OrderID != null)
                {
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
                else
                {
                    Application.Current.MainPage = new MainPage();
                }
            }
        }
    }
}
