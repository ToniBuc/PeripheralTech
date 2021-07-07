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
    public class ProductVideoListViewModel : BaseViewModel
    {
        private readonly APIService _productVideoService = new APIService("ProductVideo");
        private readonly APIService _productService = new APIService("Product");
        public int? ProductID { get; set; }
        public ProductVideoListViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ProductVideo> ProductVideoList { get; set; } = new ObservableCollection<ProductVideo>();
        public ICommand InitCommand { get; set; }

        private string _pageTitle = string.Empty;
        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }
        public async Task Init()
        {
            var product = await _productService.GetById<Model.Product>(ProductID);
            PageTitle = product.Company.Name + " " + product.Name + " Videos";
            var search = new ProductVideoSearchRequest()
            {
                ProductID = ProductID.Value
            };

            var productVideoList = await _productVideoService.Get<List<Model.ProductVideo>>(search);
            ProductVideoList.Clear();
            foreach (var x in productVideoList)
            {
                ProductVideoList.Add(x);
            }
        }
    }
}
