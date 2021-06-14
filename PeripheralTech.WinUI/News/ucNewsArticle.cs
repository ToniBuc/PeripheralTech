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

namespace PeripheralTech.WinUI.News
{
    public partial class ucNewsArticle : UserControl
    {
        private readonly APIService _newsService = new APIService("News");
        private readonly APIService _userService = new APIService("User");
        private int? _id = null;
        public ucNewsArticle(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }

        private async void ucNewsArticle_Load(object sender, EventArgs e)
        {
            
            if (_id.HasValue)
            {
                var article = await _newsService.GetById<Model.News>(_id);
                var user = await _userService.GetById<Model.User>(article.UserID);

                lblUserDate.Text = user.FirstName + " \"" + user.Username + "\" " + user.LastName + "  - " + article.Date.ToShortDateString();

                txtTitle.Text = article.Title;
                txtArticle.Text = article.Content;

                //loading in image
                if (article.Thumbnail.Length > 0)
                {
                    byte[] imgSource = article.Thumbnail;
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
            }
            else
            {
                lblUserDate.Text = APIService.Username + "  - " + DateTime.Now.ToShortDateString();
                pictureBox.Image = PeripheralTech.WinUI.Properties.Resources.no_image_available;
            }
        }

        NewsUpsertRequest request = new NewsUpsertRequest();
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                request.UserID = APIService.UserID;
                request.Title = txtTitle.Text;
                request.Content = txtArticle.Text;
                request.Date = DateTime.Now.Date;

                if (_id.HasValue)
                {
                    await _newsService.Update<Model.News>(_id, request);
                }
                else
                {
                    await _newsService.Insert<Model.News>(request);
                }

                MessageBox.Show("Operation successful!");
            }
        }

        private void btnAddHeader_Click(object sender, EventArgs e)
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

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }

        private void txtArticle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticle.Text))
            {
                errorProvider.SetError(txtArticle, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtArticle, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucNewsOverview uc = new ucNewsOverview();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
