using PeripheralTech.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class PictureImagePopupViewModel : BaseViewModel
    {
        private readonly APIService _productImageService = new APIService("ProductImage");
        public int? ProductImageID { get; set; }
        public PictureImagePopupViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ProductImage ProductImage { get; set; }
        public ICommand InitCommand { get; set; }

        private byte[] _image = null;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        public async Task Init()
        {

            var productImage = await _productImageService.GetById<Model.ProductImage>(ProductImageID);

            Image = productImage.Image;
        }
    }
}
