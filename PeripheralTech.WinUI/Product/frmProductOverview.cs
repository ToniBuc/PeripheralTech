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
    }
}
