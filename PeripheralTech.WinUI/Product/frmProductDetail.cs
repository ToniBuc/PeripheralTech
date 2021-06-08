using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripheralTech.WinUI.Product
{
    public partial class frmProductDetail : Form
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productTypeService = new APIService("ProductType");
        private readonly APIService _companyService = new APIService("Company");
        private int? _id = null;
        public frmProductDetail(int? Id = null)
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

        private async void frmProductDetail_Load(object sender, EventArgs e)
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

        //making the form movable using the upper panel
        #region Panel Border
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnGallery_Click(object sender, EventArgs e)
        {
            if (_id != null)
            {
                frmProductGallery frm = new frmProductGallery(_id.Value);
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.Show();
            }
        }
    }
}
