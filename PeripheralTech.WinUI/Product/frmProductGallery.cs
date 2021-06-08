﻿using PeripheralTech.Model.Requests;
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
    public partial class frmProductGallery : Form
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productImageService = new APIService("ProductImage");
        private int _id;
        public frmProductGallery(int Id)
        {
            InitializeComponent();
            _id = Id;
        }

        private async Task LoadProductImages(ProductImageSearchRequest search)
        {
            var imageList = await _productImageService.Get<List<Model.ProductImage>>(search);

            dgvImages.AutoGenerateColumns = false;
            dgvImages.DataSource = imageList;
        }

        private async void frmProductGallery_Load(object sender, EventArgs e)
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
    }
}