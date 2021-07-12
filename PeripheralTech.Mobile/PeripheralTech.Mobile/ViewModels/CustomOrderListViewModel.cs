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
    public class CustomOrderListViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        public CustomOrderListViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            //UserId = APIService.UserID;

            var search = new ProductSearchRequest()
            {
                AvailableForCustom = true
            };

            var list = await _productService.Get<IEnumerable<Product>>(search);

            ProductList.Clear();

            foreach (var x in list)
            {
                ProductList.Add(x);
            }
        }
    }
}
