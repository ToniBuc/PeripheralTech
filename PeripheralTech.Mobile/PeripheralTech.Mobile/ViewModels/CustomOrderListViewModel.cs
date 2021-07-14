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
    public class CustomOrderListViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _orderUnderReviewService = new APIService("Order/GetUnderReviewOrder");
        private readonly APIService _orderApprovedService = new APIService("Order/GetApprovedOrder");
        public CustomOrderListViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public ICommand InitCommand { get; set; }

        private bool _checkOrder = false;
        public bool CheckOrder
        {
            get { return _checkOrder; }
            set { SetProperty(ref _checkOrder, value); }
        }

        public async Task Init()
        {
            //UserId = APIService.UserID;

            var orderSearch = new OrderSearchRequest()
            {
                UserID = APIService.UserID
            };

            var order = await _orderUnderReviewService.Get<Model.Order>(orderSearch);

            if (order == null)
            {
                order = await _orderApprovedService.Get<Model.Order>(orderSearch);
            }

            if (order != null)
            {
                CheckOrder = true;
            }

            var search = new ProductSearchRequest()
            {
                AvailableForCustom = true
            };

            var list = await _productService.Get<IEnumerable<Product>>(search);

            ProductList.Clear();

            foreach (var x in list)
            {
                ProductList.Add(x);
            }
        }
    }
}
