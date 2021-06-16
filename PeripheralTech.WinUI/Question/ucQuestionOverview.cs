using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeripheralTech.Model.Requests;

namespace PeripheralTech.WinUI.Question
{
    public partial class ucQuestionOverview : UserControl
    {
        private readonly APIService _questionService = new APIService("Question");
        public ucQuestionOverview()
        {
            InitializeComponent();
        }

        private async Task LoadQuestions(QuestionSearchRequest search)
        {
            var questionList = await _questionService.Get<List<Model.Question>>(search);

            dgvQuestions.AutoGenerateColumns = false;
            dgvQuestions.DataSource = questionList;
        }

        private async Task LoadClaims()
        {
            cmbClaimed.Items.Insert(0, "All");
            cmbClaimed.Items.Insert(1, "Claimed");
            cmbClaimed.Items.Insert(2, "Unclaimed");
            cmbClaimed.Items.Insert(3, "My Claims");
        }

        private async void ucQuestionOverview_Load(object sender, EventArgs e)
        {
            await LoadQuestions(null);
            await LoadClaims();
            cmbClaimed.SelectedIndex = 0;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new QuestionSearchRequest()
            {
                Status = cbxActive.Checked
            };

            //assigning Claim
            if (cmbClaimed.Text == "All")
            {
                search.Claim = "All";
            }
            else if (cmbClaimed.Text == "Claimed")
            {
                search.Claim = "Claimed";
            }
            else if (cmbClaimed.Text == "Unclaimed")
            {
                search.Claim = "Unclaimed";
            }
            else if (cmbClaimed.Text == "My Claims")
            {
                search.StaffID = APIService.UserID;
            }


            await LoadQuestions(search);
        }

        private void dgvQuestions_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvQuestions.RowCount.Equals(0))
            {
                var id = dgvQuestions.SelectedRows[0].Cells[0].Value;
                ucQuestionComments uc = new ucQuestionComments(int.Parse(id.ToString()));
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
