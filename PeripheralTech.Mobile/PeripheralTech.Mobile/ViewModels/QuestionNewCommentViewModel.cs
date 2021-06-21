using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class QuestionNewCommentViewModel : BaseViewModel
    {
        private readonly APIService _questionCommentService = new APIService("QuestionComment");
        private readonly APIService _questionService = new APIService("Question");
        public int? QuestionID { get; set; }
        public QuestionNewCommentViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Submit());
        }

        public ICommand InitCommand { get; set; }
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

        public async Task Init()
        {
            var question = await _questionService.GetById<Question>(QuestionID);
            QuestionTitle = question.Title;
        }
        public async Task Submit()
        {
            var request = new QuestionCommentUpsertRequest()
            {
                QuestionID = QuestionID.Value,
                UserID = APIService.UserID,
                Date = DateTime.Now,
                Content = Content
            };

            if (string.IsNullOrWhiteSpace(Content))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You can not send an empty reply, please write something before attempting to send it in!", "OK");
            }
            else
            {
                await _questionCommentService.Insert<Model.QuestionComment>(request);
                await Application.Current.MainPage.DisplayAlert("Notification", "Your reply has been successfully sent!", "OK");
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
