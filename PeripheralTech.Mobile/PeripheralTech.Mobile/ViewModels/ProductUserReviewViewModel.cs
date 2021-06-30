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
    public class ProductUserReviewViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _userReviewService = new APIService("UserReview");
        public int? ProductID { get; set; }
        public ProductUserReviewViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Submit());
        }

        public ObservableCollection<int> RatingList { get; set; } = new ObservableCollection<int>();

        public ICommand InitCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        #region Initialization
        private string _procedure = string.Empty;
        public string Product
        {
            get { return _procedure; }
            set { SetProperty(ref _procedure, value); }
        }

        private int _rating = 0;
        public int Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        #endregion

        public async Task Init()
        {
            var product = await _productService.GetById<Product>(ProductID);

            var search = new UserReviewSearchRequest()
            {
                ProductID = product.ProductID,
                UserID = APIService.UserID
            };
            var userReview = await _userReviewService.Get<List<UserReview>>(search);

            if (product != null && userReview.Count == 1)
            {
                Product = product.Name;
                Description = userReview[0].Comment;
                Rating = Convert.ToInt32(userReview[0].Grade);
                RatingList.Clear();
                for (int i = 1; i < 6; i++)
                {
                    RatingList.Add(i);
                }
            }
            else if (product != null && userReview.Count == 0)
            {
                Product = product.Name;
                RatingList.Clear();
                for (int i = 1; i < 6; i++)
                {
                    RatingList.Add(i);
                }
            }
        }
        public async Task Submit()
        {
            var product = await _productService.GetById<Product>(ProductID);
            var request = new UserReviewUpsertRequest()
            {
                ProductID = product.ProductID,
                UserID = APIService.UserID,
                Date = DateTime.Now,
                Grade = Rating,
                Comment = Description
            };

            var search = new UserReviewSearchRequest()
            {
                ProductID = product.ProductID,
                UserID = APIService.UserID
            };
            var rating = await _userReviewService.Get<List<UserReview>>(search);

            if (request.Grade != 0)
            {
                if (rating.Count == 1)
                {
                    await _userReviewService.Update<Model.UserReview>(rating[0].UserReviewID, request);
                    await Application.Current.MainPage.DisplayAlert("Notification", "You have successfully updated your rating of this procedure!", "OK");
                }
                else
                {
                    await _userReviewService.Insert<Model.UserReview>(request);
                    await Application.Current.MainPage.DisplayAlert("Notification", "You have successfully given this procedure a rating!", "OK");
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "There was an error during the rating process of the procedure, please make sure you have entered all the required information correctly.", "OK");
            }
        }
    }
}
