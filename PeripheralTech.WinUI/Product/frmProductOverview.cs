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
    public partial class frmProductOverview : Form
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productTypeService = new APIService("ProductType");
        private readonly APIService _companyService = new APIService("Company");
        public frmProductOverview()
        {
            InitializeComponent();
        }

        private async Task LoadProducts(ProductSearchRequest search)
        {
            var productList = await _productService.Get<List<Model.Product>>(search);

            foreach (var x in productList)
            {
                if (x.Thumbnail.Length == 0)
                {
                    x.Thumbnail = ImageToByteArray(PeripheralTech.WinUI.Properties.Resources.no_image_available);
                }
            }

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = productList;
            
        }

        private async Task LoadProductTypes()
        {
            var result = await _productTypeService.Get<List<Model.ProductType>>(null);
            result.Insert(0, new Model.ProductType());
            result[0].Name = "All";
            cmbProductType.DisplayMember = "Name";
            cmbProductType.ValueMember = "ProductTypeID";
            cmbProductType.DataSource = result;
        }
        private async Task LoadCompanies()
        {
            var result = await _companyService.Get<List<Model.Company>>(null);
            result.Insert(0, new Model.Company());
            result[0].Name = "All";
            cmbManufacturer.DisplayMember = "Name";
            cmbManufacturer.ValueMember = "CompanyID";
            cmbManufacturer.DataSource = result;
        }

        private async Task LoadOrderByPrice()
        {
            cmbOrderByPrice.Items.Insert(0, "");
            cmbOrderByPrice.Items.Insert(1, "Low to High");
            cmbOrderByPrice.Items.Insert(2, "High to Low");
        }

        private async Task LoadInStock()
        {
            cmbInStock.Items.Insert(0, "");
            cmbInStock.Items.Insert(1, "In stock");
            cmbInStock.Items.Insert(2, "Out of stock");
        }

        public static byte[] ImageToByteArray(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private async void frmProductOverview_Load(object sender, EventArgs e)
        {
            await LoadProducts(null);
            await LoadProductTypes();
            await LoadCompanies();
            await LoadOrderByPrice();
            await LoadInStock();
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
        //
        #endregion

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            frmProductDetail frm = new frmProductDetail();
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.Show();
        }

        private void dgvProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvProducts.RowCount.Equals(0))
            {
                var id = dgvProducts.SelectedRows[0].Cells[0].Value;
                frmProductDetail frm = new frmProductDetail(int.Parse(id.ToString()));
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.Show();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new ProductSearchRequest()
            {
                ProductName = txtProductName.Text
            };

            var productType = cmbProductType.SelectedValue;
            if (int.TryParse(productType.ToString(), out int typeId))
            {
                if (typeId != 0)
                {
                    search.ProductTypeID = typeId;
                }
            }

            var company = cmbManufacturer.SelectedValue;
            if (int.TryParse(company.ToString(), out int companyId))
            {
                if (companyId != 0)
                {
                    search.CompanyID = companyId;
                }
            }

            //assigning OrderByPrice
            if (cmbOrderByPrice.Text == "")
            {
                search.OrderByPrice = "All";
            }
            else if (cmbOrderByPrice.Text == "Low to High")
            {
                search.OrderByPrice = "Low to High";
            }
            else if (cmbOrderByPrice.Text == "High to Low")
            {
                search.OrderByPrice = "High to Low";
            }

            //assigning InStock
            if (cmbInStock.Text == "")
            {
                search.InStock = "All";
            }
            else if (cmbInStock.Text == "In stock")
            {
                search.InStock = "In stock";
            }
            else if (cmbInStock.Text == "Out of stock")
            {
                search.InStock = "Out of stock";
            }

            await LoadProducts(search);
        }
    }
}
