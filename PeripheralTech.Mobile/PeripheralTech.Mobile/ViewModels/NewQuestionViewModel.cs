using PeripheralTech.Mobile.Views;
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
    public class NewQuestionViewModel : BaseViewModel
    {
        private readonly APIService _questionService = new APIService("Question");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _orderProductService = new APIService("OrderProduct");
        private readonly APIService _orderUnderReviewService = new APIService("Order/GetUnderReviewOrder");
        //public int? OrderID { get; set; }
        public bool? CustomOrderCheck { get; set; }
        public NewQuestionViewModel()
        {
            //InitCommand = new Command(async () => await Init());
            SubmitCommand = new Command(async () => await Submit());
        }
        //public ICommand InitCommand { get; set; }
        public ObservableCollection<Product> CustomOrderList { get; set; } = new ObservableCollection<Product>();
        public ICommand SubmitCommand { get; set; }

        #region Initialization
        private string _questionTitle = string.Empty;
        public string QuestionTitle
        {
            get { return _questionTitle; }
            set { SetProperty(ref _questionTitle, value); }
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
        #endregion

        //public async Task Init()
        //{
        //    var question = await _questionService.GetById<Question>(QuestionID);
        //    QuestionTitle = question.Title;
        //}
        public async Task Submit()
        {
            bool check = false;
            int? OrderID = null;
            if (CustomOrderCheck != null && CustomOrderCheck == true)
            {
                var request = new OrderInsertRequest()
                {
                    Date = DateTime.Now,
                    UserID = APIService.UserID,
                    OrderStatusID = 4
                };

                try
                {
                    await _orderService.Insert<Model.Order>(request);

                    //int? tempId = null;
                    if (!check)
                    {
                        var searchOrder = new OrderSearchRequest()
                        {
                            UserID = APIService.UserID
                        };
                        var order = await _orderUnderReviewService.Get<Model.Order>(searchOrder);

                        if (order != null)
                        {
                            foreach (var x in CustomOrderList)
                            {
                                var orderProductRequest = new OrderProductUpsertRequest()
                                {
                                    OrderID = order.OrderID,
                                    ProductID = x.ProductID
                                };
                                try
                                {
                                    await _orderProductService.Insert<Model.Product>(orderProductRequest);
                                }
                                catch (Exception)
                                {
                                    check = true;
                                }
                            }
                            OrderID = order.OrderID;
                        }
                        else
                        {
                            check = true;
                        }
                    }
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "There was an error during the ordering process, please make sure you have entered all the required information correctly.", "OK");
                    check = true;
                }
            }

            if (!check)
            {
                //await Application.Current.MainPage.DisplayAlert("Notification", "You have successfully placed a custom order!", "OK");
                var questionRequest = new QuestionInsertRequest()
                {
                    CustomerID = APIService.UserID,
                    Date = DateTime.Now,
                    Title = QuestionTitle,
                    Content = Content,
                    Status = true
                };

                if (OrderID != null)
                {
                    questionRequest.OrderID = OrderID;
                }

                if (string.IsNullOrWhiteSpace(Content) || string.IsNullOrWhiteSpace(QuestionTitle))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Both the Title and Content fields can not be empty, please fill them in before attempting to send the question in!", "OK");
                }
                else
                {
                    await _questionService.Insert<Model.Question>(questionRequest);
                    
                    if (OrderID != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Notification", "Your custom order and it's associated question have been successfully sent!", "OK");
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        await Application.Current.MainPage.Navigation.PopModalAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Notification", "Your question has been successfully sent!", "OK");
                        Application.Current.MainPage = new MainPage();
                    }
                }
            }
        }
    }
}
