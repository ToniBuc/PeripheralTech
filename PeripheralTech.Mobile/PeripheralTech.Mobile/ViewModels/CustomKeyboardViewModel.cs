using PeripheralTech.Mobile.Views;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class CustomKeyboardViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _orderUnderReviewService = new APIService("Order/GetUnderReviewOrder");
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _productCustomService = new APIService("Product/GetProductsForCustomOrder");
        public int? ProductID { get; set; }
        public CustomKeyboardViewModel()
        {
            InitCommand = new Command(async () => await Init());
            OrderCommand = new Command(async () => await Order());
        }
        public ObservableCollection<Product> CustomOrderList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> CasingList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> KeycapList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> SoundDampenerList { get; set; } = new ObservableCollection<Product>();

        public ICommand InitCommand { get; set; }
        public ICommand PickProductCommand { get; set; }
        public ICommand RemoveProductCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public Product Product { get; set; }
        private string _totalString = string.Empty;
        public string TotalString
        {
            get { return _totalString; }
            set { SetProperty(ref _totalString, value); }
        }
        public async Task Init()
        {
            Product = await _productService.GetById<Model.Product>(ProductID);
            var search = new ProductSearchRequest()
            {
                ProductID = ProductID
            };

            bool prodCheck = true;
            foreach (var x in CustomOrderList)
            {
                if (x.ProductID == Product.ProductID)
                {
                    prodCheck = false;
                }
            }

            if (prodCheck)
            {
                CustomOrderList.Add(Product);
            }

            var list = await _productCustomService.Get<IEnumerable<Product>>(search);

            CasingList.Clear();
            KeycapList.Clear();
            SoundDampenerList.Clear();
            foreach (var x in list)
            {
                if (x.ProductTypeName.Equals("Keyboard Casing"))
                {
                    CasingList.Add(x);
                }
                else if (x.ProductTypeName.Equals("Keycaps"))
                {
                    KeycapList.Add(x);
                }
                else if (x.ProductTypeName.Equals("Keyboard Sound Dampeners"))
                {
                    SoundDampenerList.Add(x);
                }
            }
        }
        public async Task PickProduct(int id)
        {
            var product = await _productService.GetById<Model.Product>(id);

            CustomOrderList.Add(product);

            //below part is done so that the size of the cells within the collectionview
            //will be based on the product with the longest ProductNamePrice string, in order to avoid lost text
            //has to stay like this until I learn of a better way to get the same result
            List<Model.Product> list = CustomOrderList.ToList();
            list = list.OrderByDescending(i => i.ProductNamePrice).ToList();
            decimal total = 0;
            CustomOrderList.Clear();
            foreach (var x in list)
            {
                CustomOrderList.Add(x);
                total += x.Price;
            }
            TotalString = "Total: " + Math.Round(total, 2) + " KM";
        }
        public async Task RemoveProduct(int id)
        {
            decimal total = 0;
            foreach (var x in CustomOrderList.ToList())
            {
                if (x.ProductID == id)
                {
                    CustomOrderList.Remove(x);
                    total += x.Price;
                }
            }
            TotalString = "Total: " + Math.Round(total, 2) + " KM";
        }
        public async Task Order()
        {
            bool isCustomOrder = true;
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new NewQuestionPage(CustomOrderList, isCustomOrder)));

            //bool check = false;
            //var request = new OrderInsertRequest()
            //{
            //    Date = DateTime.Now,
            //    UserID = APIService.UserID,
            //    OrderStatusID = 4
            //};

            //try
            //{
            //    await _orderService.Insert<Model.Order>(request);
            //}
            //catch (Exception)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "There was an error during the ordering process, please make sure you have entered all the required information correctly.", "OK");
            //    check = true;
            //}

            //int? tempId = null;
            //if (!check)
            //{
            //    var searchOrder = new OrderSearchRequest()
            //    {
            //        UserID = APIService.UserID
            //    };
            //    var order = await _orderUnderReviewService.Get<Model.Order>(searchOrder);

            //    if (order != null)
            //    {
            //        foreach (var x in CustomOrderList)
            //        {
            //            var orderProductRequest = new OrderProductUpsertRequest()
            //            {
            //                OrderID = order.OrderID,
            //                ProductID = x.ProductID
            //            };
            //            try
            //            {
            //                await _orderProductService.Insert<Model.Product>(orderProductRequest);
            //            }
            //            catch (Exception)
            //            {
            //                check = true;
            //            }
            //        }
            //        tempId = order.OrderID;
            //    }
            //    else
            //    {
            //        check = true;
            //    }
            //}

            //if (!check)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Notification", "You have successfully placed a custom order!", "OK");
            //    await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new NewQuestionPage(tempId)));
            //}
        }
    }
}
