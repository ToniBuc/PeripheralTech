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
    public class ProductStaffReviewViewModel : BaseViewModel
    {
        private readonly APIService _staffReviewService = new APIService("StaffReview");
        private readonly APIService _productService = new APIService("Product");
        public int? ProductID { get; set; }
        public ProductStaffReviewViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public List<StaffReview> StaffReview { get; set; } = new List<StaffReview>();
        public Product Product { get; set; }
        //public StaffReview StaffReview { get; set; }
        public ICommand InitCommand { get; set; }

        #region Initialization
        private string _productName = string.Empty;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }
        private string _reviewer = string.Empty;
        public string Reviewer
        {
            get { return _reviewer; }
            set { SetProperty(ref _reviewer, value); }
        }
        private string _specifications = string.Empty;
        public string Specifications
        {
            get { return _specifications; }
            set { SetProperty(ref _specifications, value); }
        }
        private string _reviewContent = string.Empty;
        public string ReviewContent
        {
            get { return _reviewContent; }
            set { SetProperty(ref _reviewContent, value); }
        }
        private decimal _rating = 0;
        public decimal Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        #endregion

        public async Task Init()
        {
            Product = await _productService.GetById<Model.Product>(ProductID);
            var search = new StaffReviewSearchRequest()
            {
                ProductID = ProductID
            };

            StaffReview = await _staffReviewService.Get<List<StaffReview>>(search);
            if (StaffReview.Count == 1)
            {
                ProductName = Product.Company.Name + " " + Product.Name;
                Reviewer = StaffReview[0].User.FirstName + " " + StaffReview[0].User.LastName;
                Specifications = StaffReview[0].Specifications;
                ReviewContent = StaffReview[0].ReviewContent;
                Rating = StaffReview[0].Grade;
            }

        }
    }
}
