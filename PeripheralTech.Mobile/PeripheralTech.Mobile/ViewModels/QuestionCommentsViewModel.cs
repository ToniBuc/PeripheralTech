using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class QuestionCommentsViewModel : BaseViewModel
    {
        private readonly APIService _questionCommentService = new APIService("QuestionComment");
        private readonly APIService _questionService = new APIService("Question");
        public int? QuestionID { get; set; }
        public QuestionCommentsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<QuestionComment> CommentList { get; set; } = new ObservableCollection<QuestionComment>();
        public Question Question { get; set; }
        public ICommand InitCommand { get; set; }

        private string _questionTitle = string.Empty;
        public string QuestionTitle
        {
            get { return _questionTitle; }
            set { SetProperty(ref _questionTitle, value); }
        }

        public async Task Init()
        {
            Question = await _questionService.GetById<Model.Question>(QuestionID);
            QuestionTitle = Question.Title;

            var search = new QuestionCommentSearchRequest()
            {
                QuestionID = QuestionID
            };

            var commentList = await _questionCommentService.Get<List<QuestionComment>>(search);
            if (CommentList.Count == 0)
            {
                foreach (var x in commentList)
                {
                    CommentList.Add(x);
                }
            }
        }
    }
}
