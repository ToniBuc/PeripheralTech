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

namespace PeripheralTech.WinUI.Company
{
    public partial class frmCompanyOverview : Form
    {
        private readonly APIService _companyService = new APIService("Company");
        public frmCompanyOverview()
        {
            InitializeComponent();
        }

        private async void frmCompanyOverview_Load(object sender, EventArgs e)
        {
            var companyList = await _companyService.Get<List<Model.Company>>(null);

            dgvCompanies.AutoGenerateColumns = false;
            dgvCompanies.DataSource = companyList;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CompanySearchRequest()
            {
                CompanyName = txtSearch.Text
            };
            var companyList = await _companyService.Get<List<Model.Company>>(search);

            dgvCompanies.AutoGenerateColumns = false;
            dgvCompanies.DataSource = companyList;
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
