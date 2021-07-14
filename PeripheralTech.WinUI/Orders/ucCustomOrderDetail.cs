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
using PeripheralTech.WinUI.Question;

namespace PeripheralTech.WinUI.Orders
{
    public partial class ucCustomOrderDetail : UserControl
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _questionService = new APIService("Question");
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private int? _id = null;
        public ucCustomOrderDetail(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }

        private async void ucCustomOrderDetail_Load(object sender, EventArgs e)
        {
            txtUser.ReadOnly = true;
            txtDate.ReadOnly = true;
            if (_id.HasValue)
            {
                var search = new OrderProductSearchRequest()
                {
                    OrderID = _id,
                    CustomOrderProductsCheck = true
                };
                var list = await _orderProductService.Get<List<Model.OrderProduct>>(search);

                dgvProducts.AutoGenerateColumns = false;
                dgvProducts.DataSource = list;

                var order = await _orderService.GetById<Model.Order>(_id);

                if (order.OrderStatusName == "Approved")
                {
                    btnApprove.Enabled = false;
                }

                txtUser.Text = order.UserFullname;
                txtDate.Text = order.DateShort;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucOrderOverview uc = new ucOrderOverview();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }

        private async void btnQuestion_Click(object sender, EventArgs e)
        {
            var questionSearch = new QuestionSearchRequest()
            {
                OrderID = _id
            };
            var question = await _questionService.Get<List<Model.Question>>(questionSearch);

            if (question.Count > 0)
            {
                if (question[0].StaffID == APIService.UserID || APIService.Role == "Administrator")
                {
                    ucQuestionComments uc = new ucQuestionComments(null, _id);
                    this.Parent.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.BringToFront();
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("You do not have permission to access this question because it was already claimed by another staff member!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            var order = await _orderService.GetById<Model.Order>(_id);

            var request = new OrderUpdateRequest()
            {
                OrderStatusID = 5,
                Comment = order.Comment,
                Date = order.Date
            };

            await _orderService.Update<Model.Order>(_id, request);
        }
    }
}
