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
using PeripheralTech.WinUI.Orders;

namespace PeripheralTech.WinUI.Question
{
    public partial class ucQuestionComments : UserControl
    {
        private readonly APIService _questionService = new APIService("Question");
        private readonly APIService _commentsService = new APIService("QuestionComment");
        private int? _id = null;
        private int? _orderId = null;
        private int? _secondQId = null;
        public ucQuestionComments(int? Id = null, int ? orderId = null)
        {
            InitializeComponent();
            _id = Id;
            _orderId = orderId;
        }

        private async Task LoadReplies()
        {
            if (_id != null)
            {
                var search = new QuestionCommentSearchRequest()
                {
                    QuestionID = _id
                };
                var replyList = await _commentsService.Get<List<Model.QuestionComment>>(search);

                dgvReplies.AutoGenerateColumns = false;
                dgvReplies.DataSource = replyList;
            }
            else if (_secondQId != null)
            {
                var search = new QuestionCommentSearchRequest()
                {
                    QuestionID = _secondQId
                };
                var replyList = await _commentsService.Get<List<Model.QuestionComment>>(search);

                dgvReplies.AutoGenerateColumns = false;
                dgvReplies.DataSource = replyList;
            }
        }

        private async void ucQuestionComments_Load(object sender, EventArgs e)
        {
            if (_id == null)
            {
                var questionSearch = new QuestionSearchRequest()
                {
                    OrderID = _orderId
                };
                var q = await _questionService.Get<List<Model.Question>>(questionSearch);
                if (q.Count > 0)
                {
                    _secondQId = q[0].QuestionID;
                }
            }

            await LoadReplies();

            Model.Question question = new Model.Question();
            if (_id != null)
            {
                question = await _questionService.GetById<Model.Question>(_id);
            }
            else if (_secondQId != null)
            {
                question = await _questionService.GetById<Model.Question>(_secondQId);
            }
            
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
                    //QuestionID = _id.Value,
                    Content = txtReply.Text,
                    Date = DateTime.Now
                };

                if (_id != null)
                {
                    request.QuestionID = _id.Value;
                }
                else if (_secondQId != null)
                {
                    request.QuestionID = _secondQId.Value;
                }

                await _commentsService.Insert<Model.QuestionComment>(request);
                await LoadReplies();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_id != null)
            {
                ucQuestionOverview uc = new ucQuestionOverview();
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
            else if (_orderId != null)
            {
                ucCustomOrderDetail uc = new ucCustomOrderDetail(_orderId);
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
        }

        private async void btnClaim_Click(object sender, EventArgs e)
        {
            var request = new QuestionUpdateRequest()
            {
                StaffID = APIService.UserID
            };

            if (_id != null)
            {
                await _questionService.Update<Model.Question>(_id, request);
            }
            else if (_secondQId != null)
            {
                await _questionService.Update<Model.Question>(_secondQId, request);
            }

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

            if (_id != null)
            {
                await _questionService.Update<Model.Question>(_id, request);
            }
            else if (_secondQId != null)
            {
                await _questionService.Update<Model.Question>(_secondQId, request);
            }

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
