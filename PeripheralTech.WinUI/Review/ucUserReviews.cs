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
using PeripheralTech.WinUI.Product;

namespace PeripheralTech.WinUI.Review
{
    public partial class ucUserReviews : UserControl
    {
        private readonly APIService _userReviewService = new APIService("UserReview");
        private readonly APIService _productService = new APIService("Product");
        private int? _id = null;
        private int _productId;
        public ucUserReviews(int productId, int? Id = null)
        {
            InitializeComponent();
            _id = Id;
            _productId = productId;
        }

        private async void ucUserReviews_Load(object sender, EventArgs e)
        {
            var product = await _productService.GetById<Model.Product>(_productId);
            lblProductName.Text = product.Name;

            var search = new UserReviewSearchRequest()
            {
                ProductID = _productId
            };

            var reviewList = await _userReviewService.Get<List<Model.UserReview>>(search);

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = reviewList;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucProductDetail uc = new ucProductDetail(_productId);
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
