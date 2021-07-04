using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderService = new APIService("Order");
        public OrdersViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Order> OrderList { get; set; } = new ObservableCollection<Order>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var search = new OrderSearchRequest()
            {
                UserID = APIService.UserID,
                OrderStatus = "NotActive"
            };

            var orderList = await _orderService.Get<List<Model.Order>>(search);

            OrderList.Clear();
            foreach (var x in orderList)
            {
                x.TotalPayment = Math.Round(x.TotalPayment, 2);
                OrderList.Add(x);
            }
        }
    }
}
