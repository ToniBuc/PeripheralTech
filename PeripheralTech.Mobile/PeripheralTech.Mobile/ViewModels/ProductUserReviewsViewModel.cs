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
    public class ProductUserReviewsViewModel : BaseViewModel
    {
        private readonly APIService _userReviewService = new APIService("UserReview");
        private readonly APIService _productService = new APIService("Product");
        public int? ProductID { get; set; }
        public ProductUserReviewsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<UserReview> UserReviewList { get; set; } = new ObservableCollection<UserReview>();
        public Product Product { get; set; }
        public ICommand InitCommand { get; set; }

        private string _productName = string.Empty;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        public async Task Init()
        {
            Product = await _productService.GetById<Model.Product>(ProductID);
            ProductName = Product.Company.Name + " " + Product.Name;
            var search = new UserReviewSearchRequest()
            {
                ProductID = ProductID
            };

            var ratingList = await _userReviewService.Get<List<Model.UserReview>>(search);
            UserReviewList.Clear();
            foreach (var x in ratingList)
            {
                UserReviewList.Add(x);
            }
        }
    }
}
