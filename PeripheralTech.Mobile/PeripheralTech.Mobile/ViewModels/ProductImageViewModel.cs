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
    public class ProductImageViewModel : BaseViewModel
    {
        private readonly APIService _productImageService = new APIService("ProductImage");
        private readonly APIService _productService = new APIService("Product");
        public int? ProductID { get; set; }
        public ProductImageViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<ProductImage> ProductImageList { get; set; } = new ObservableCollection<ProductImage>();
        public ICommand InitCommand { get; set; }

        private string _productName = string.Empty;
        public string ProductName
        {
            get { return _productName; }
            set { SetProperty(ref _productName, value); }
        }

        public async Task Init()
        {
            var product = await _productService.GetById<Model.Product>(ProductID);
            ProductName = product.Company.Name + " " + product.Name + " Images";
            var search = new ProductImageSearchRequest()
            {
                ProductID = ProductID.Value
            };

            var productImageList = await _productImageService.Get<List<Model.ProductImage>>(search);
            ProductImageList.Clear();
            foreach (var x in productImageList)
            {
                ProductImageList.Add(x);
            }
        }
    }
}
