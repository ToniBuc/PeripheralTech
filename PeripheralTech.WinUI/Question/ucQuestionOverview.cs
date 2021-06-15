using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripheralTech.WinUI.Question
{
    public partial class ucQuestionOverview : UserControl
    {
        private readonly APIService _questionService = new APIService("Question");
        public ucQuestionOverview()
        {
            InitializeComponent();
        }

        private async void ucQuestionOverview_Load(object sender, EventArgs e)
        {
            var questionList = await _questionService.Get<List<Model.Question>>(null);

            dgvQuestions.AutoGenerateColumns = false;
            dgvQuestions.DataSource = questionList;
        }
    }
}
