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

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = orderList;
        }

        private async Task LoadOrderStatus()
        {
            cmbOrderStatus.Items.Insert(0, "");
            cmbOrderStatus.Items.Insert(1, "Done");
            cmbOrderStatus.Items.Insert(2, "Pending");
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

            await LoadOrders(search);
        }
    }
}
