using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PeripheralTech.Model.Requests;

namespace PeripheralTech.WinUI.Reports
{
    public partial class ucCompanyReport : UserControl
    {
        private readonly APIService _companyService = new APIService("Company");
        public ucCompanyReport()
        {
            InitializeComponent();
        }

        private void ucCompanyReport_Load(object sender, EventArgs e)
        {
            reportViewer.ZoomMode = ZoomMode.PageWidth;


        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            var search = new CompanySearchRequest()
            {
                From = dtpFrom.Value,
                To = dtpTo.Value
            };

            var companies = await _companyService.Get<List<Model.Company>>(search);

            if (companies != null)
            {
                CompanyBindingSource.DataSource = companies;
                ReportDataSource source = new ReportDataSource("dsCompanies", CompanyBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.RefreshReport();
            }
            else
            {
                CompanyBindingSource.DataSource = null;
                ReportDataSource source = new ReportDataSource("dsCompanies", CompanyBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.RefreshReport();
            }
        }

        private void dtpFrom_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                errorProvider.SetError(dtpFrom, "The From date can not be after the To date!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpFrom, null);
            }
        }

        private void dtpTo_Validating(object sender, CancelEventArgs e)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                errorProvider.SetError(dtpFrom, "The To date can not be before the From date!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpFrom, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
