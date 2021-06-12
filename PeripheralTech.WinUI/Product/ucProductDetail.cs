using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PeripheralTech.Model.Requests;
using System.Text.RegularExpressions;
using PeripheralTech.WinUI.Review;

namespace PeripheralTech.WinUI.Product
{
    public partial class ucProductDetail : UserControl
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productTypeService = new APIService("ProductType");
        private readonly APIService _companyService = new APIService("Company");
        private readonly APIService _staffReviewService = new APIService("StaffReview");
        private int? _id = null;
        public ucProductDetail(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }

        private async Task LoadProductTypes()
        {
            var result = await _productTypeService.Get<List<Model.ProductType>>(null);
            result.Insert(0, new Model.ProductType());
            cmbProductType.DisplayMember = "Name";
            cmbProductType.ValueMember = "ProductTypeID";
            cmbProductType.DataSource = result;
        }
        private async Task LoadCompanies()
        {
            var result = await _companyService.Get<List<Model.Company>>(null);
            result.Insert(0, new Model.Company());
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.ValueMember = "CompanyID";
            cmbManufacturer.DataSource = result;
        }

        private async void ucProductDetail_Load(object sender, EventArgs e)
        {
            await LoadProductTypes();
            await LoadCompanies();
            if (_id.HasValue)
            {
                var product = await _productService.GetById<Model.Product>(_id);
                //loading in image
                if (product.Thumbnail.Length > 0)
                {
                    byte[] imgSource = product.Thumbnail;
                    Bitmap image;
                    using (MemoryStream stream = new MemoryStream(imgSource))
                    {
                        image = new Bitmap(stream);
                    }
                    pictureBox.Image = image;
                }
                else
                {
                    pictureBox.Image = PeripheralTech.WinUI.Properties.Resources.no_image_available;
                }
                lblProduct.Text = product.Name;
                txtProductName.Text = product.Name;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                cmbProductType.SelectedItem = product.ProductTypeID;
                cmbProductType.SelectedText = product.ProductTypeName;
                cmbProductType.SelectedValue = product.ProductTypeID;
                cmbManufacturer.SelectedItem = product.CompanyID;
                cmbManufacturer.SelectedText = product.CompanyName;
                cmbManufacturer.SelectedValue = product.CompanyID;
                numInStock.Value = product.AmountInStock;
            }
            else
            {
                pictureBox.Image = PeripheralTech.WinUI.Properties.Resources.no_image_available;
            }
        }

        ProductUpsertRequest request = new ProductUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.Name = txtProductName.Text;
                request.Description = txtDescription.Text;
                request.Price = decimal.Parse(txtPrice.Text);
                request.AmountInStock = Convert.ToInt32(numInStock.Value);

                var productType = cmbProductType.SelectedValue;
                if (int.TryParse(productType.ToString(), out int productTypeId))
                {
                    request.ProductTypeID = productTypeId;
                }

                var company = cmbManufacturer.SelectedValue;
                if (int.TryParse(company.ToString(), out int companyId))
                {
                    request.CompanyID = companyId;
                }

                if (_id != null)
                {
                    await _productService.Update<Model.Product>(_id, request);
                }
                else
                {
                    await _productService.Insert<Model.Product>(request);
                }

                MessageBox.Show("Operation successful!");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);

                request.Thumbnail = file;
                txtImageInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                pictureBox.Image = image;
            }
        }

        private void txtProductName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtProductName, null);
            }
        }

        private void cmbProductType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbProductType.SelectedValue.Equals(0))
            {
                errorProvider.SetError(cmbProductType, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbProductType, null);
            }
        }

        private void cmbManufacturer_Validating(object sender, CancelEventArgs e)
        {
            if (cmbManufacturer.SelectedValue.Equals(0))
            {
                errorProvider.SetError(cmbManufacturer, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbManufacturer, null);
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            string regex = @"^[0-9]+(\,[0-9]{1,2})?$";
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                errorProvider.SetError(txtPrice, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtPrice.Text, regex))
            {
                errorProvider.SetError(txtPrice, "This field must contain a valid format for money! Example: 15 or 50,50");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrice, null);
            }
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            if (_id != null)
            {
                ucProductGallery uc = new ucProductGallery(_id.Value);
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
        }

        private async void btnReview_Click(object sender, EventArgs e)
        {
            if (_id != null)
            {
                var search = new StaffReviewSearchRequest()
                {
                    ProductID = _id.Value
                };

                var review = await _staffReviewService.Get<List<Model.StaffReview>>(search);

                ucStaffReview uc;

                if (review.Count != 0)
                {
                    uc = new ucStaffReview(_id.Value, review[0].StaffReviewID);
                }
                else
                {
                    uc = new ucStaffReview(_id.Value, null);
                }
                
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
