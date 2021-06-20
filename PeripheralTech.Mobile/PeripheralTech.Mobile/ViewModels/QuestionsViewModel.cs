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
    public class QuestionsViewModel : BaseViewModel
    {
        private readonly APIService _questionService = new APIService("Question");
        public QuestionsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Question> QuestionList { get; set; } = new ObservableCollection<Question>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            //UserId = APIService.UserID;

            var search = new QuestionSearchRequest()
            {
                CustomerID = APIService.UserID
            };

            var list = await _questionService.Get<IEnumerable<Question>>(search);

            QuestionList.Clear();

            foreach (var x in list)
            {
                QuestionList.Add(x);
            }
        }
    }
}
