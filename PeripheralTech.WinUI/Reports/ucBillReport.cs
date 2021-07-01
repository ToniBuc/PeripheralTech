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
    public partial class ucBillReport : UserControl
    {
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _billService = new APIService("Bill");
        private int? _id = null;
        public ucBillReport(int? Id = null)
        {
            InitializeComponent();
            _id = Id;
        }

        private async void reportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.ZoomMode = ZoomMode.PageWidth;

            var bill = await _billService.GetById<Model.Bill>(_id);
            var search = new OrderProductSearchRequest()
            {
                OrderID = bill.OrderID
            };

            var orderProducts = await _orderProductService.Get<List<Model.OrderProduct>>(search);

            if (orderProducts != null && bill != null)
            {
                OrderProductBindingSource.DataSource = orderProducts;
                BillBindingSource.DataSource = bill;
                ReportDataSource source = new ReportDataSource("dsOrderProducts", OrderProductBindingSource);
                ReportDataSource source2 = new ReportDataSource("dsOrderProducts", OrderProductBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.LocalReport.DataSources.Add(source2);
                this.reportViewer.RefreshReport();
            }
            else
            {
                OrderProductBindingSource.DataSource = null;
                BillBindingSource.DataSource = null;
                ReportDataSource source = new ReportDataSource("dsOrderProducts", OrderProductBindingSource);
                ReportDataSource source2 = new ReportDataSource("dsOrderProducts", OrderProductBindingSource);
                this.reportViewer.LocalReport.DataSources.Add(source);
                this.reportViewer.LocalReport.DataSources.Add(source2);
                this.reportViewer.RefreshReport();
            }
        }
    }
}
