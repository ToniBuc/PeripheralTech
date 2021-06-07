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
    public partial class frmProductOverview : Form
    {
        private readonly APIService _productService = new APIService("Product");
        public frmProductOverview()
        {
            InitializeComponent();
        }

        private async Task LoadProducts(ProductSearchRequest search)
        {
            var productList = await _productService.Get<List<Model.Product>>(search);

            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.DataSource = productList;
        }

        private async void frmProductOverview_Load(object sender, EventArgs e)
        {
            await LoadProducts(null);
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
    }
}
