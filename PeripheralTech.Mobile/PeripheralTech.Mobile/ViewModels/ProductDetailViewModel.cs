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
    public class ProductDetailViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _userReviewService = new APIService("UserReview");
        private readonly APIService _staffReviewService = new APIService("StaffReview");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _recommendedService = new APIService("Product/RecommendedProducts");
        public int? ProductID { get; set; }
        public ProductDetailViewModel()
        {
            InitCommand = new Command(async () => await Init());
            AddToCartCommand = new Command(async () => await AddToCart());
        }
        public ObservableCollection<Product> RecommendedProductList { get; set; } = new ObservableCollection<Product>();
        public List<UserReview> UserReviewList { get; set; } = new List<UserReview>();
        public List<StaffReview> StaffReview { get; set; } = new List<StaffReview>();
        public List<OrderProduct> OrderProduct { get; set; } = new List<OrderProduct>();
        public Product Product { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }

        #region Initialization
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        private string _price = string.Empty;
        public string Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }
        private string _companyName = string.Empty;
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }
        private string _amountInStock = string.Empty;
        public string AmountInStock
        {
            get { return _amountInStock; }
            set { SetProperty(ref _amountInStock, value); }
        }
        private float _rating = 0;
        public float Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        private byte[] _thumbnail = null;
        public byte[] Thumbnail
        {
            get { return _thumbnail; }
            set { SetProperty(ref _thumbnail, value); }
        }
        #endregion

        public async Task Init()
        {
            Product = await _productService.GetById<Model.Product>(ProductID);
            var search = new UserReviewSearchRequest()
            {
                ProductID = ProductID
            };

            UserReviewList = await _userReviewService.Get<List<UserReview>>(search);
            if (UserReviewList.Count > 0)
            {
                float listCount = UserReviewList.Count;
                float listSum = new int();
                foreach (var x in UserReviewList)
                {
                    listSum += Convert.ToInt32(x.Grade);
                }

                Rating = listSum / listCount;
            }

            if (Product != null)
            {
                Name = Product.Name;
                Description = Product.Description;
                if (Product.Discounted)
                {
                    Price = Product.DiscountedPrice + " " + Product.DiscountedString;
                }
                else
                {
                    Price = Product.Price.ToString() + " KM";
                }
                AmountInStock = Product.AmountInStock.ToString();
                CompanyName = Product.CompanyName;
                Thumbnail = Product.Thumbnail;
            }

            var searchStaffReview = new StaffReviewSearchRequest()
            {
                ProductID = ProductID
            };

            StaffReview = await _staffReviewService.Get<List<StaffReview>>(searchStaffReview);

            var list = await _recommendedService.GetById<IEnumerable<Product>>(ProductID);

            RecommendedProductList.Clear();
            foreach (var x in list)
            {
                RecommendedProductList.Add(x);
            }

            //var searchOrderProduct = new OrderProductSearchRequest()
            //{
            //    ProductID = ProductID
            //};

            //OrderProduct = await _orderProductService.Get<List<Model.OrderProduct>>(searchOrderProduct);
        }
        public async Task AddToCart()
        {
            var search = new OrderSearchRequest()
            {
                UserID = APIService.UserID,
                OrderStatus = "Active"
            };

            var order = await _orderService.Get<List<Model.Order>>(search);

            if (order.Count == 1)
            {
                var orderProductRequest = new OrderProductUpsertRequest()
                {
                    OrderID = order[0].OrderID,
                    ProductID = ProductID
                };
                await _orderProductService.Insert<Model.OrderProduct>(orderProductRequest);
                await Application.Current.MainPage.DisplayAlert("Notification", "Product successfully added to your shopping cart!", "OK");
            }
            else if (order.Count == 0)
            {
                var orderRequest = new OrderInsertRequest()
                {
                    UserID = APIService.UserID,
                    Date = DateTime.Now,
                    OrderStatusID = 1
                };

                await _orderService.Insert<Model.Order>(orderRequest);

                var newOrder = await _orderService.Get<List<Model.Order>>(search);

                var orderProductRequest = new OrderProductUpsertRequest()
                {
                    OrderID = newOrder[0].OrderID,
                    ProductID = ProductID
                };
                await _orderProductService.Insert<Model.OrderProduct>(orderProductRequest);
                await Application.Current.MainPage.DisplayAlert("Notification", "Product successfully added to your shopping cart!", "OK");
            }
        }
    }
}
