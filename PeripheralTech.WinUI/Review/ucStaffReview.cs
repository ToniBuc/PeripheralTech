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
    public partial class ucStaffReview : UserControl
    {
        private readonly APIService _staffReviewService = new APIService("StaffReview");
        private readonly APIService _productService = new APIService("Product");
        private int? _id = null;
        private int _productId;
        public ucStaffReview(int productId, int? Id = null)
        {
            InitializeComponent();
            _id = Id;
            _productId = productId;
        }

        private async Task LoadGrades()
        {
            for (int i = 0; i < 5; i++)
            {
                cmbRating.Items.Insert(i, i + 1);
            }
        }

        private async void ucStaffReview_Load(object sender, EventArgs e)
        {
            await LoadGrades();
            var product = await _productService.GetById<Model.Product>(_productId);
            lblUserDate.Text = APIService.Username + "  - " + DateTime.Now.ToShortDateString();
            lblProductName.Text = product.Name;

            if (_id.HasValue)
            {
                var review = await _staffReviewService.GetById<Model.StaffReview>(_id);
                txtReview.Text = review.ReviewContent;
                txtSpecifications.Text = review.Specifications;
                cmbRating.SelectedIndex = Convert.ToInt32(review.Grade) - 1;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new StaffReviewUpsertRequest()
                {
                    ProductID = _productId,
                    UserID = APIService.UserID,
                    Specifications = txtSpecifications.Text,
                    ReviewContent = txtReview.Text,
                    Date = DateTime.Now.Date,
                    Grade = Decimal.Parse(cmbRating.Text)
                };

                if (_id.HasValue)
                {
                    await _staffReviewService.Update<Model.StaffReview>(_id, request);
                }
                else
                {
                    await _staffReviewService.Insert<Model.StaffReview>(request);
                }

                MessageBox.Show("Operation successful!");
            }
        }

        private void txtSpecifications_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSpecifications.Text))
            {
                errorProvider.SetError(txtSpecifications, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtSpecifications, null);
            }
        }

        private void txtReview_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReview.Text))
            {
                errorProvider.SetError(txtReview, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtReview, null);
            }
        }

        private void cmbRating_Validating(object sender, CancelEventArgs e)
        {
            if (cmbRating.SelectedValue.Equals(0))
            {
                errorProvider.SetError(cmbRating, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbRating, null);
            }
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
