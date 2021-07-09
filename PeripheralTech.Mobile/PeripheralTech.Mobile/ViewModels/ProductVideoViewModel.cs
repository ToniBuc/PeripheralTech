using MediaManager;
using PeripheralTech.Mobile.Helpers;
using PeripheralTech.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class ProductVideoViewModel : BaseViewModel
    {
        private readonly APIService _productVideoService = new APIService("ProductVideo");
        public int? ProductVideoID { get; set; }
        public ProductVideoViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ICommand InitCommand { get; set; }

        private ProductVideo productVideo;
        public ProductVideo ProductVideo
        {
            get { return productVideo; }
            set
            {
                productVideo = value;
                OnPropertyChanged();
            }
        }
        public string fileName { get; set; }

        public async Task Init()
        {
            ProductVideo = await _productVideoService.GetById<Model.ProductVideo>(ProductVideoID);

            var video = CrossMediaManager.Current;
            fileName = FileHelper.SaveFile(productVideo.Video, Guid.NewGuid() + ".mp4");
            if (!string.IsNullOrEmpty(fileName))
            {
                await video.Play(fileName);

                video.MediaItemFinished += (sender, args) =>
                {
                    FileHelper.DeleteFile(fileName);
                };
            }
        }
    }
}
