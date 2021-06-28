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
    public class CheckoutViewModel : BaseViewModel
    {
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderService = new APIService("Order");
        public CheckoutViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RemoveCommand = new Command(async () => await Remove(OrderProductID.Value));
        }
        public ObservableCollection<OrderProduct> OrderProductList { get; set; } = new ObservableCollection<OrderProduct>();
        public Order Order { get; set; }
        public int ? OrderProductID = null;
        public ICommand InitCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        #region Initialization
        private string _totalPayment = string.Empty;
        public string TotalPayment
        {
            get { return _totalPayment; }
            set { SetProperty(ref _totalPayment, value); }
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
            var searchOrder = new OrderSearchRequest()
            {
                UserID = APIService.UserID,
                OrderStatus = "Active"
            };

            var order = await _orderService.Get<List<Model.Order>>(searchOrder);

            if (order.Count > 0)
            {
                Order = order[0];

                var searchOrderProduct = new OrderProductSearchRequest()
                {
                    OrderID = Order.OrderID
                };

                var orderProductList = await _orderProductService.Get<List<Model.OrderProduct>>(searchOrderProduct);

                var totalPayment = new decimal();
                OrderProductList.Clear();
                foreach (var x in orderProductList)
                {
                    OrderProductList.Add(x);
                    totalPayment += x.Product.Price;
                }
                TotalPayment = "Total payment: " + totalPayment;
                //Order.Comment = Comment;
            }
        }
        public async Task Remove(int id)
        {
            await _orderProductService.Delete<Model.OrderProduct>(id);
            //await Init();
        }
    }
}
