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
    public class OrderDetailsViewModel : BaseViewModel
    {
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderService = new APIService("Order");
        public int? OrderID { get; set; }
        public OrderDetailsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<OrderProduct> OrderProductList { get; set; } = new ObservableCollection<OrderProduct>();
        public Order Order { get; set; }
        public ICommand InitCommand { get; set; }

        #region Initialization
        private string _dateAndPrice = string.Empty;
        public string DateAndPrice
        {
            get { return _dateAndPrice; }
            set { SetProperty(ref _dateAndPrice, value); }
        }
        private string _comment = string.Empty;
        public string Comment
        {
            get { return _comment; }
            set { SetProperty(ref _comment, value); }
        }
        #endregion

        public async Task Init()
        {
            Order = await _orderService.GetById<Model.Order>(OrderID);

            var searchOrderProduct = new OrderProductSearchRequest()
            {
                OrderID = OrderID,
                MyOrdersCheck = true
            };

            var orderProductList = await _orderProductService.Get<List<Model.OrderProduct>>(searchOrderProduct);

            OrderProductList.Clear();
            foreach (var x in orderProductList)
            {
                OrderProductList.Add(x);
            }

            DateAndPrice = Order.DateShort + " - " + Math.Round(Order.TotalPayment, 2);
            Comment = Order.Comment;
        }
    }
}
