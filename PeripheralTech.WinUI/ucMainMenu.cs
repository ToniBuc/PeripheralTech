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

namespace PeripheralTech.WinUI
{
    public partial class ucMainMenu : UserControl
    {
        private readonly APIService _questionService = new APIService("Question");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _productService = new APIService("Product");
        public ucMainMenu()
        {
            InitializeComponent();
        }

        private async void ucMainMenu_Load(object sender, EventArgs e)
        {
            var welcomeMessage = "Welcome " + APIService.Username;
            lblWelcome.Text = welcomeMessage;

            var questionSearchOne = new QuestionSearchRequest()
            {
                Claim = "Unclaimed"
            };
            var questionsOne = await _questionService.Get<List<Model.Question>>(questionSearchOne);
            lblQuestionNumber.Text = questionsOne.Count().ToString();

            var questionSearchTwo = new QuestionSearchRequest()
            {
                Status = true,
                StaffID = APIService.UserID
            };
            var questionsTwo = await _questionService.Get<List<Model.Question>>(questionSearchTwo);
            lblQuestionNumberTwo.Text = questionsTwo.Count().ToString();

            var orderSearch = new OrderSearchRequest()
            {
                OrderStatus = "Pending"
            };
            var orders = await _orderService.Get<List<Model.Order>>(orderSearch);
            lblOrderNumber.Text = orders.Count().ToString();

            var productSearch = new ProductSearchRequest()
            {
                AmountInStock = 0
            };
            var products = await _productService.Get<List<Model.Order>>(productSearch);
            lblProductNumber.Text = products.Count().ToString();
        }
    }
}