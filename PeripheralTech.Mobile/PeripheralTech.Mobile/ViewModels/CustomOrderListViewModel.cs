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
        private readonly APIService _productCustomizableService = new APIService("Product/GetCustomizableProducts");
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
        private string _searchText = null;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                OnPropertyChanged();
            }

        }

        public async Task Init()
        {
            //var search = new ProductSearchRequest()
            //{
            //    AvailableForCustom = true
            //};
            //var list = await _productService.Get<IEnumerable<Model.Product>>(search);

            //ProcedureList.Clear();
            //if (_searchText != null)
            //{
            //    var normalizedQuery = _searchText?.ToLower() ?? "";
            //    foreach (var x in list)
            //    {
            //        if (x.Name.ToLowerInvariant().Contains(normalizedQuery))
            //        {
            //            ProcedureList.Add(x);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var x in list)
            //    {
            //        ProcedureList.Add(x);
            //    }
            //}

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

            var list = await _productCustomizableService.Get<IEnumerable<Product>>(null);

            ProductList.Clear();
            if (_searchText != null)
            {
                var normalizedQuery = _searchText?.ToLower() ?? "";
                foreach (var x in list)
                {
                    if (x.Name.ToLowerInvariant().Contains(normalizedQuery))
                    {
                        ProductList.Add(x);
                    }
                }
            }
            else
            {
                foreach (var x in list)
                {
                    ProductList.Add(x);
                }
            }

            //foreach (var x in list)
            //{
            //    ProductList.Add(x);
            //}
        }
    }
}
