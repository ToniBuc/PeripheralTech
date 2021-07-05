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
        private readonly APIService _productVideoService = new APIService("ProductVideo");
        private int _id;
        private int counter = 0;
        public ucProductGallery(int Id)
        {
            InitializeComponent();
            _id = Id;
        }
        private async void ucProductGallery_Load(object sender, EventArgs e)
        {
            var productSearch = new ProductSearchRequest()
            {
                ProductID = _id
            };
            //var product = await _productService.GetById<Model.Product>(_id);
            var product = await _productService.Get<List<Model.Product>>(productSearch);
            //lblProductName.Text = product[0].Name;

            var searchImages = new ProductImageSearchRequest()
            {
                ProductID = _id
            };

            await LoadProductImages(searchImages);

            var searchVideos = new ProductVideoSearchRequest()
            {
                ProductID = _id
            };

            await LoadProductVideos(searchVideos);

            await LoadTitle();
        }
        private async Task LoadProductImages(ProductImageSearchRequest search)
        {
            var imageList = await _productImageService.Get<List<Model.ProductImage>>(search);

            dgvImages.AutoGenerateColumns = false;
            dgvImages.DataSource = imageList;
            dgvImages.ClearSelection();
        }

        private async Task LoadTitle()
        {
            var productSearch = new ProductSearchRequest()
            {
                ProductID = _id
            };
            var product = await _productService.GetById<Model.Product>(_id);
            //var product = await _productService.Get<List<Model.Product>>(productSearch);
            lblProductName.Text = product.Name;
        }

        private async Task LoadProductVideos(ProductVideoSearchRequest search)
        {
            var videoList = await _productVideoService.Get<List<Model.ProductVideo>>(search);
            videoList.Insert(0, new Model.ProductVideo());
            cmbVideos.DisplayMember = "Title";
            cmbVideos.ValueMember = "ProductVideoID";
            cmbVideos.DataSource = videoList;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucProductDetail uc = new ucProductDetail(_id);
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }

        private async void btnAddVideo_Click(object sender, EventArgs e)
        {
            var request = new ProductVideoUpsertRequest()
            {
                ProductID = _id
            };

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);

                request.Video = file;
                request.Title = Path.GetFileName(fileName);
                txtVideoInput.Text = fileName;
            }

            //var file = GetFile();
            var list = new string[] { ".mp4" };
            if (!list.Contains(Path.GetExtension(txtVideoInput.Text)))
            {
                MessageBox.Show("The selected file does not have a supported format.");
            }
            else
            {
                await _productVideoService.Insert<Model.ProductVideo>(request);

                MessageBox.Show("Operation successful!");

                var search = new ProductVideoSearchRequest()
                {
                    ProductID = _id
                };

                await LoadProductVideos(search);

            }
        }

        private async void btnPlayVideo_Click(object sender, EventArgs e)
        {
            if (cmbVideos.SelectedItem == null || cmbVideos.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a video to be played.");
            }
            else
            {

                var video = await _productVideoService.GetById<Model.ProductVideo>(cmbVideos.SelectedValue);

                Guid g = Guid.NewGuid();
                string file = video.Title + "-" + g.ToString() + ".mp4";
                File.WriteAllBytes(file, video.Video);
                axWindowsMediaPlayer1.URL = file;
                axWindowsMediaPlayer1.settings.autoStart = true;
            }
        }
    }
}
