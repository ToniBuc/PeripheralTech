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
    public class ProductsViewModel : BaseViewModel
    {
        private readonly APIService _productService = new APIService("Product");
        private readonly APIService _productTypeService = new APIService("ProductType");
        private readonly APIService _companyService = new APIService("Company");
        public ProductsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        private string _searchText = null;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                OnPropertyChanged();
            }

        }

        public Company _selectedCompany;
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set { SetProperty(ref _selectedCompany, value); OnPropertyChanged(); }
        }

        public ProductType _selectedProductType;
        public ProductType SelectedProductType
        {
            get { return _selectedProductType; }
            set { SetProperty(ref _selectedProductType, value); OnPropertyChanged(); }
        }

        public ObservableCollection<Product> ProductList { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Company> CompanyList { get; set; } = new ObservableCollection<Company>();
        public ObservableCollection<ProductType> ProductTypeList { get; set; } = new ObservableCollection<ProductType>();
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var search = new ProductSearchRequest();
            int productTypeId;
            int companyId;

            if (SelectedProductType != null)
            {
                productTypeId = SelectedProductType.ProductTypeID;
                search.ProductTypeID = productTypeId;
            }

            if (SelectedCompany != null)
            {
                companyId = SelectedCompany.CompanyID;
                search.CompanyID = companyId;
            }

            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                search.ProductName = SearchText;
            }

            IEnumerable<Model.Product> list;
            if (search.CompanyID.HasValue || search.ProductTypeID.HasValue)
            {
                list = await _productService.Get<IEnumerable<Model.Product>>(search);
            }
            else
            {
                list = await _productService.Get<IEnumerable<Model.Product>>(null);
            }

            var companyList = await _companyService.Get<IEnumerable<Model.Company>>(null);
            var productTypeList = await _productTypeService.Get<IEnumerable<Model.ProductType>>(null);

            CompanyList.Clear();
            foreach (var x in companyList)
            {
                CompanyList.Add(x);
            }

            ProductTypeList.Clear();
            foreach (var x in productTypeList)
            {
                ProductTypeList.Add(x);
            }

            ProductList.Clear();
            foreach (var x in list)
            {
                ProductList.Add(x);
            }
        }
    }
}
