using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripheralTech.WinUI.Product
{
    public partial class frmAddAsPart : Form
    {
        private readonly APIService _productService = new APIService("Product");
        private int? _id = null;
        public frmAddAsPart(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }
        private async Task LoadProducts()
        {
            var search = new ProductSearchRequest()
            {
                AvailableForCustom = true
            };

            var result = await _productService.Get<List<Model.Product>>(search);
            result.Insert(0, new Model.Product());
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.DataSource = result;
        }

        private async void frmAddAsPart_Load(object sender, EventArgs e)
        {
            await LoadProducts();
            if (_id.HasValue)
            {
                var product = await _productService.GetById<Model.Product>(_id);
                if (product.ProductMadeForID.HasValue)
                {
                    cmbProduct.SelectedItem = product.ProductMadeForID;
                    cmbProduct.SelectedText = product.ProductMadeFor.Name;
                    cmbProduct.SelectedValue = product.ProductMadeForID;
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                var product = await _productService.GetById<Model.Product>(_id);
                ProductUpsertRequest request = new ProductUpsertRequest()
                {
                    AmountInStock = product.AmountInStock,
                    AvailableForCustom = product.AvailableForCustom,
                    CompanyID = product.CompanyID,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    ProductTypeID = product.ProductTypeID
                };

                var productFor = cmbProduct.SelectedValue;
                if (int.TryParse(productFor.ToString(), out int productForId))
                {
                    request.ProductMadeForID = productForId;
                }

                if (cmbProduct.SelectedValue.Equals(0))
                {
                    MessageBox.Show("You must pick a customizable product to add this as a part to before attempting to save!");
                }
                else
                {
                    await _productService.Update<Model.Product>(_id, request);

                    MessageBox.Show("Operation successful!");
                }
            }
        }

        //making the form movable using the upper panel
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
    }
}
