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
    public partial class ucBillReport : UserControl
    {
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _billService = new APIService("Bill");
        private int? _orderId = null;
        public ucBillReport(int? Id = null)
        {
            InitializeComponent();
            _orderId = Id;
        }

        private async void ucBillReport_Load(object sender, EventArgs e)
        {
            var searchBill = new BillSearchRequest()
            {
                OrderID = _orderId
            };

            var bill = await _billService.Get<List<Model.Bill>>(searchBill);
            var order = await _orderService.GetById<Model.Order>(_orderId);

            if (order.OrderStatusName == "Done")
            {
                btnConfirmOrder.Enabled = false;
            }

            if (bill.Count == 1)
            {
                var search = new OrderProductSearchRequest()
                {
                    OrderID = _orderId,
                    MyOrdersCheck = true
                };


                var orderProducts = await _orderProductService.Get<List<Model.OrderProduct>>(search);

                ReportDataSource source = new ReportDataSource("dsOrderProducts", orderProducts);
                this.reportViewer.LocalReport.DataSources.Add(source);

                this.reportViewer.LocalReport.SetParameters(new ReportParameter("User", bill[0].UserFullname));
                this.reportViewer.LocalReport.SetParameters(new ReportParameter("City", order.User.City.Name));
                this.reportViewer.LocalReport.SetParameters(new ReportParameter("Address", order.User.Address));
                this.reportViewer.LocalReport.SetParameters(new ReportParameter("User", bill[0].UserFullname));
                this.reportViewer.LocalReport.SetParameters(new ReportParameter("Date", bill[0].Date.ToShortDateString()));
                this.reportViewer.LocalReport.SetParameters(new ReportParameter("Total", bill[0].PaymentAmount.ToString() + " KM"));
            }

            this.reportViewer.RefreshReport();
        }

        private async void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            var order = await _orderService.GetById<Model.Order>(_orderId);

            var request = new OrderUpdateRequest()
            {
                OrderStatusID = 2,
                Comment = order.Comment,
                Date = order.Date
            };

            await _orderService.Update<Model.Order>(_orderId, request);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucOrderOverview uc = new ucOrderOverview();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }

        private void reportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.ZoomMode = ZoomMode.PageWidth;
        }
    }
}
