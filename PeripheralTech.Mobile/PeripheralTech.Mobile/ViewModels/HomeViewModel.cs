using PeripheralTech.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        private readonly APIService _recentProductService = new APIService("Product/GetRecentProducts");
        private readonly APIService _discountProductService = new APIService("Product/GetDiscountedProducts");
        public HomeViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Product> RecentProductList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> DiscountedProductList { get; set; } = new ObservableCollection<Product>();
        public ICommand InitCommand { get; set; }

        #region Initialization
        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        #endregion

        public async Task Init()
        {
            Username = APIService.Username;

            var recentProductList = await _recentProductService.Get<List<Model.Product>>(null);
            RecentProductList.Clear();
            foreach (var x in recentProductList)
            {
                RecentProductList.Add(x);
            }

            var discountedProductList = await _discountProductService.Get<List<Model.Product>>(null);
            DiscountedProductList.Clear();
            foreach (var x in discountedProductList)
            {
                DiscountedProductList.Add(x);
            }
        }
    }
}
