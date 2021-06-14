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

namespace PeripheralTech.WinUI.News
{
    public partial class ucNewsOverview : UserControl
    {
        private readonly APIService _newsService = new APIService("News");
        public ucNewsOverview()
        {
            InitializeComponent();
        }

        private async Task LoadNews(NewsSearchRequest search)
        {
            var newsList = await _newsService.Get<List<Model.News>>(search);

            dgvNews.AutoGenerateColumns = false;
            dgvNews.DataSource = newsList;
        }

        private async void ucNewsOverview_Load(object sender, EventArgs e)
        {
            await LoadNews(null);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new NewsSearchRequest()
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text
            };

            await LoadNews(search);
        }

        private void dgvNews_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvNews.RowCount.Equals(0))
            {
                var id = dgvNews.SelectedRows[0].Cells[0].Value;
                ucNewsArticle uc = new ucNewsArticle(int.Parse(id.ToString()));
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
        }

        private void btnNewArticle_Click(object sender, EventArgs e)
        {
            ucNewsArticle uc = new ucNewsArticle();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
