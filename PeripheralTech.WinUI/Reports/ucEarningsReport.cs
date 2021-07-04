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
using PeripheralTech.WinUI.Orders;

namespace PeripheralTech.WinUI.Reports
{
    public partial class ucEarningsReport : UserControl
    {
        private readonly APIService _billService = new APIService("Bill");
        public ucEarningsReport()
        {
            InitializeComponent();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer.ZoomMode = ZoomMode.PageWidth;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            var dateFromTemp = dtpFrom.Value.AddHours(-2);
            var dateToTemp = dtpTo.Value.AddHours(-2);
            var search = new BillSearchRequest()
            {
                From = dateFromTemp,
                To = dateToTemp,
            };

            var bills = await _billService.Get<List<Model.Bill>>(search);

            if (bills != null)
            {
                BillBindingSource.DataSource = bills;
                ReportDataSource source = new ReportDataSource("dsEarnings", BillBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.RefreshReport();
            }
            else
            {
                BillBindingSource.DataSource = null;
                ReportDataSource source = new ReportDataSource("dsEarnings", BillBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.RefreshReport();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucOrderOverview uc = new ucOrderOverview();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
