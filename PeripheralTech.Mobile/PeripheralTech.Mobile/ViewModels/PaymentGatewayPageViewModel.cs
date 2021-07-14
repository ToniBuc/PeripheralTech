using Acr.UserDialogs;
using PeripheralTech.Mobile.Models;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using Prism.Commands;
using Prism.Mvvm;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class PaymentGatewayPageViewModel : BindableBase
    {
        private readonly APIService _billService = new APIService("Bill");
        private readonly APIService _orderService = new APIService("Order");
        private readonly APIService _productService = new APIService("Product");
        public INavigation Navigation { get; set; }

        #region Variable

        //public Bill Bill { get; set; }
        public Model.Order Order { get; set; }
        public List<Model.Product> ProductList { get; set; }
        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransectionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;

        #endregion Variable

        #region Public Property
        private string StripeTestApiKey = "sk_test_51Ib6B2JhVMhcCyrFZbeDa0u0bs7mih9SVy4FVRgS9no93EjhbODqI7l2kTU4LdIyMCiUaGaV9FIOzz3BtGAYcqzH00sBUIw11E";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransectionSuccess
        {
            get { return _isTransectionSuccess; }
            set { SetProperty(ref _isTransectionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public PaymentGatewayPageViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
        }

        #endregion Constructor

        #region Command

        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Payment processing..");
                await Task.Run(async () =>
                {

                    var Token = CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransectionSuccess = MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Bad card credentials", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
                Console.Write("Payment Gatway" + ex.Message);
            }
            finally
            {
                if (IsTransectionSuccess)
                {
                    Console.Write("Payment Gateway" + "Payment Successful ");

                    //keep this in mind, will need to be changed
                    //var request = new BillUpsertRequest()
                    //{
                    //    IsPaid = true
                    //};

                    //var entity = await _service.Update<Bill>(Bill.BillID, request);

                    var request = new BillUpsertRequest()
                    {
                        OrderID = Order.OrderID,
                        Date = DateTime.Now,
                        PaymentAmount = Order.TotalPayment,
                        IsPaid = true
                    };

                    await _billService.Insert<Model.Bill>(request);

                    //changed from active or approved to pending
                    var orderRequest = new OrderUpdateRequest()
                    {
                        OrderStatusID = 3,
                        Comment = Order.Comment,
                        Date = DateTime.Now
                    };

                    await _orderService.Update<Model.Order>(Order.OrderID, orderRequest);

                    foreach (var x in ProductList)
                    {
                        var updateProduct = new ProductUpsertRequest()
                        {
                            AmountInStock = x.AmountInStock - 1,
                            AvailableForCustom = x.AvailableForCustom,
                            CompanyID = x.CompanyID,
                            Description = x.Description,
                            Name = x.Name,
                            Price = x.Price,
                            ProductMadeForID = x.ProductMadeForID,
                            ProductTypeID = x.ProductTypeID,
                            Thumbnail = x.Thumbnail
                        };

                        await _productService.Update<Model.Product>(x.ProductID, updateProduct);
                    }

                    UserDialogs.Instance.Alert("Payment successful!,", "OK", "OK");
                    UserDialogs.Instance.HideLoading();
                }
                else
                {

                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Oops, something went wrong", "Payment failed", "OK");
                    Console.Write("Payment Gateway" + "Payment Failure ");
                }
            }

        });

        #endregion Command

        #region Method

        private string CreateToken()
        {
            try
            {
                //StripeConfiguration.SetApiKey(StripeTestApiKey); // obsolete
                StripeConfiguration.ApiKey = StripeTestApiKey;
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = APIService.Username,
                        AddressLine1 = APIService.User.Address,
                        //AddressLine2 = "SpringBoard",
                        AddressCity = APIService.User.City.Name,
                        AddressZip = APIService.User.City.ZIPCode,
                        AddressCountry = APIService.User.City.Country.Name,
                        Currency = "bam",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool MakePayment(string token)
        {
            try
            {
                //StripeConfiguration.SetApiKey(StripeTestApiKey); // obsolete
                StripeConfiguration.ApiKey = StripeTestApiKey;
                var options = new ChargeCreateOptions
                {
                    Amount = (long)Order.TotalPayment * 100,
                    Currency = "bam",
                    Description = "Charge for user: " + APIService.Username,
                    Source = stripeToken.Id,
                    StatementDescriptor = "Custom descriptor",
                    Capture = true,
                    ReceiptEmail = APIService.User.Email,
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gateway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
            }
            return true;
        }

        #endregion Method
    }
}
