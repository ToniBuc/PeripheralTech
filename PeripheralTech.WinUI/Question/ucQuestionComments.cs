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
    public partial class ucQuestionComments : UserControl
    {
        private readonly APIService _questionService = new APIService("Question");
        private readonly APIService _commentsService = new APIService("QuestionComment");
        private int? _id = null;
        public ucQuestionComments(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }

        private async Task LoadReplies()
        {
            var search = new QuestionCommentSearchRequest()
            {
                QuestionID = _id
            };
            var replyList = await _commentsService.Get<List<Model.QuestionComment>>(search);

            dgvReplies.AutoGenerateColumns = false;
            dgvReplies.DataSource = replyList;
        }

        private async void ucQuestionComments_Load(object sender, EventArgs e)
        {
            await LoadReplies();

            var question = await _questionService.GetById<Model.Question>(_id);
            txtQuestion.Text = question.Content;

            if (!question.StaffID.HasValue)
            {
                btnClose.Enabled = false;
                btnSend.Enabled = false;
            }
            else
            {
                btnClaim.Enabled = false;
            }

            if (question.Status == false)
            {
                btnClose.Enabled = false;
                btnSend.Enabled = false;
                btnClaim.Enabled = false;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new QuestionCommentUpsertRequest()
                {
                    UserID = APIService.UserID,
                    QuestionID = _id.Value,
                    Content = txtReply.Text,
                    Date = DateTime.Now
                };

                await _commentsService.Insert<Model.QuestionComment>(request);
                await LoadReplies();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucQuestionOverview uc = new ucQuestionOverview();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }

        private async void btnClaim_Click(object sender, EventArgs e)
        {
            var request = new QuestionUpdateRequest()
            {
                StaffID = APIService.UserID
            };

            await _questionService.Update<Model.Question>(_id, request);

            MessageBox.Show("Question claimed!");

            btnClose.Enabled = true;
            btnSend.Enabled = true; 
            btnClaim.Enabled = false;
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            var request = new QuestionUpdateRequest()
            {
                Status = false
            };

            await _questionService.Update<Model.Question>(_id, request);

            MessageBox.Show("Question closed!");

            btnClose.Enabled = false;
            btnSend.Enabled = false;
            btnClaim.Enabled = false;
        }

        private void txtReply_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReply.Text))
            {
                errorProvider.SetError(txtReply, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtReply, null);
            }
        }
    }
}
