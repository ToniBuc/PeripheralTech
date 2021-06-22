using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
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
        public int? ProductID { get; set; }
        public ProductDetailViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public List<UserReview> UserReviewList { get; set; } = new List<UserReview>();
        public Product Product { get; set; }
        public ICommand InitCommand { get; set; }

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
                Price = Product.Price.ToString();
                AmountInStock = Product.AmountInStock.ToString();
                CompanyName = Product.CompanyName;
                Thumbnail = Product.Thumbnail;
            }
        }
    }
}
