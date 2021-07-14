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
using PeripheralTech.WinUI.Reports;

namespace PeripheralTech.WinUI.Orders
{
    public partial class ucOrderOverview : UserControl
    {
        private readonly APIService _orderService = new APIService("Order"); 
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderStatusService = new APIService("OrderStatus");
        public ucOrderOverview()
        {
            InitializeComponent();
        }
        private async Task LoadOrders(OrderSearchRequest search)
        {
            var orderList = await _orderService.Get<List<Model.Order>>(search);

            foreach(var x in orderList)
            {
                x.TotalPayment = Math.Round(x.TotalPayment, 2);
            }

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = orderList;
        }

        private async Task LoadOrderStatus()
        {
            //cmbOrderStatus.Items.Insert(0, "");
            //cmbOrderStatus.Items.Insert(1, "Done");
            //cmbOrderStatus.Items.Insert(2, "Pending");
            var result = await _orderStatusService.Get<List<Model.OrderStatus>>(null);
            foreach (var x in result.ToList())
            {
                if (x.Name.Equals("Active"))
                {
                    result.Remove(x);
                }
            }

            result.Insert(0, new Model.OrderStatus());
            
            cmbOrderStatus.DisplayMember = "Name";
            cmbOrderStatus.ValueMember = "OrderStatusID";
            cmbOrderStatus.DataSource = result;
        }

        private async void ucOrderOverview_Load(object sender, EventArgs e)
        {
            var search = new OrderSearchRequest()
            {
                OrderStatus = "NotActive"
            };
            await LoadOrders(search);
            await LoadOrderStatus();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new OrderSearchRequest();
            if (cmbOrderStatus.Text == "")
            {
                search.OrderStatus = "NotActive";
            }
            else if (cmbOrderStatus.Text == "Done")
            {
                search.OrderStatus = "Done";
            }
            else if (cmbOrderStatus.Text == "Pending")
            {
                search.OrderStatus = "Pending";
            }
            else if (cmbOrderStatus.Text == "Under Review")
            {
                search.OrderStatus = "Under Review";
            }
            else if (cmbOrderStatus.Text == "Approved")
            {
                search.OrderStatus = "Approved";
            }

            await LoadOrders(search);
        }

        private async void dgvOrders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvOrders.RowCount.Equals(0))
            {
                var id = dgvOrders.SelectedRows[0].Cells[0].Value;

                var order = await _orderService.GetById<Model.Order>(int.Parse(id.ToString()));

                if (order.OrderStatus.Name.Equals("Under Review") || order.OrderStatus.Name.Equals("Approved"))
                {
                    ucCustomOrderDetail uc = new ucCustomOrderDetail(int.Parse(id.ToString()));
                    this.Parent.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.BringToFront();
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    ucBillReport uc = new ucBillReport(int.Parse(id.ToString()));
                    this.Parent.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.BringToFront();
                    this.Parent.Controls.Remove(this);
                }
                
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ucEarningsReport uc = new ucEarningsReport();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
