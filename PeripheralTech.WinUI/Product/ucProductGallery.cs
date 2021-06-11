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
using System.IO;

namespace PeripheralTech.WinUI.Product
{
    public partial class ucProductGallery : UserControl
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productImageService = new APIService("ProductImage");
        private int _id;
        public ucProductGallery(int Id)
        {
            InitializeComponent();
            _id = Id;
        }

        private async Task LoadProductImages(ProductImageSearchRequest search)
        {
            var imageList = await _productImageService.Get<List<Model.ProductImage>>(search);

            dgvImages.AutoGenerateColumns = false;
            dgvImages.DataSource = imageList;
            dgvImages.ClearSelection();
        }

        private async void ucProductGallery_Load(object sender, EventArgs e)
        {
            var product = await _productService.GetById<Model.Product>(_id);
            lblProductName.Text = product.Name;

            var search = new ProductImageSearchRequest()
            {
                ProductID = _id
            };

            await LoadProductImages(search);
        }

        private async void btnAddImage_Click(object sender, EventArgs e)
        {
            var request = new ProductImageUpsertRequest()
            {
                ProductID = _id
            };

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);

                request.Image = file;
                txtImageInput.Text = fileName;
            }

            await _productImageService.Insert<Model.ProductImage>(request);

            MessageBox.Show("Operation successful!");

            var search = new ProductImageSearchRequest()
            {
                ProductID = _id
            };

            await LoadProductImages(search);
        }

        private void dgvImages_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgvImages.Rows[e.RowIndex].Selected)
            {
                using (Pen pen = new Pen(Color.DarkRed))
                {
                    int penWidth = 2;

                    pen.Width = penWidth;

                    int x = e.RowBounds.Left + (penWidth / 2);
                    int y = e.RowBounds.Top + (penWidth / 2);
                    int width = e.RowBounds.Width - penWidth;
                    int height = e.RowBounds.Height - penWidth;

                    e.Graphics.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        private async void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (!dgvImages.RowCount.Equals(0) && dgvImages.SelectedRows.Count != 0)
            {
                var id = dgvImages.SelectedRows[0].Cells[0].Value;

                await _productImageService.Delete<Model.ProductImage>(int.Parse(id.ToString()));

                MessageBox.Show("Operation successful!");

                var search = new ProductImageSearchRequest()
                {
                    ProductID = _id
                };

                await LoadProductImages(search);
            }
        }
    }
}
