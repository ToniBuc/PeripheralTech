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

namespace PeripheralTech.WinUI.Company
{
    public partial class ucCompanyOverview : UserControl
    {
        private readonly APIService _companyService = new APIService("Company");
        public ucCompanyOverview()
        {
            InitializeComponent();
        }

        private async Task LoadCompanies(CompanySearchRequest search)
        {
            var companyList = await _companyService.Get<List<Model.Company>>(search);

            dgvCompanies.AutoGenerateColumns = false;
            dgvCompanies.DataSource = companyList;
        }

        private async void ucCompanyOverview_Load(object sender, EventArgs e)
        {
            await LoadCompanies(null);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CompanySearchRequest()
            {
                CompanyName = txtSearch.Text
            };

            await LoadCompanies(search);
        }

        public int? _companyId = null;
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text.Length > 0 && !txtCompanyName.Text.StartsWith(" "))
            {
                var request = new CompanyUpsertRequest()
                {
                    Name = txtCompanyName.Text
                };

                if (_companyId != null)
                {
                    await _companyService.Update<Model.Company>(_companyId, request);

                    _companyId = null;
                    txtCompanyName.Text = "";
                    lblCompany.Text = "New Company";

                    MessageBox.Show("Operation successful!");
                }
                else
                {
                    await _companyService.Insert<Model.Company>(request);

                    MessageBox.Show("Operation successful!");
                }

                await LoadCompanies(null);

            }
            else
            {
                MessageBox.Show("Please enter a company name before attempting to add a new company.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvCompanies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvCompanies.RowCount.Equals(0))
            {
                var id = dgvCompanies.SelectedRows[0].Cells[0].Value;
                _companyId = int.Parse(id.ToString());

                var company = await _companyService.GetById<Model.Company>(_companyId);

                txtCompanyName.Text = company.Name;
                lblCompany.Text = company.Name;
            }
        }
    }
}
