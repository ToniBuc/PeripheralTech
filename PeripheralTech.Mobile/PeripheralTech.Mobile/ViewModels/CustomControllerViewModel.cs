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
    public class CustomControllerViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productCustomService = new APIService("Product/GetProductsForCustomOrder"); 
        public int? ProductID { get; set; }
        public CustomControllerViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Product> CustomOrderList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> CasingList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> ButtonKitList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> ThumbstickList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> PaddlesList { get; set; } = new ObservableCollection<Product>();

        public ICommand InitCommand { get; set; }
        public Product Product { get; set; }

        public async Task Init()
        {
            Product = await _productService.GetById<Model.Product>(ProductID);
            var search = new ProductSearchRequest()
            {
                ProductID = ProductID
            };

            var list = await _productCustomService.Get<IEnumerable<Product>>(search);

            CasingList.Clear();
            ButtonKitList.Clear();
            ThumbstickList.Clear();
            PaddlesList.Clear();
            foreach (var x in list)
            {
                if (x.ProductTypeName.Equals("Controller Casing"))
                {
                    CasingList.Add(x);
                }
                else if (x.ProductTypeName.Equals("Controller Button Kit"))
                {
                    ButtonKitList.Add(x);
                }
                else if (x.ProductTypeName.Equals("Controller Thumbsticks"))
                {
                    ThumbstickList.Add(x);
                }
                else if (x.ProductTypeName.Equals("Controller Paddles"))
                {
                    PaddlesList.Add(x);
                }
            }
        }
        public async Task PickProduct(int id)
        {
            var product = await _productService.GetById<Model.Product>(id);

            CustomOrderList.Add(product);
        }
    }
}
