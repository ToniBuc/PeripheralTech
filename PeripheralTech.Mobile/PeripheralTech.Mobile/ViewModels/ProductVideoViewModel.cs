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
            PlayPauseCommand = new Command(async () => await PlayPause());
            //PauseCommand = new Command(async () => await Pause());
            LeaveCommand = new Command(async () => await Leave());
        }
        public ICommand InitCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        //public ICommand PauseCommand { get; set; }
        public ICommand LeaveCommand { get; set; }

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
        }
        public async Task PlayPause()
        {
            var video = CrossMediaManager.Current;
            bool check = true;

            if (!string.IsNullOrEmpty(fileName))
            {
                await video.PlayPause();
                check = false;
            }

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = FileHelper.SaveFile(productVideo.Video, Guid.NewGuid() + ".mp4");
            }
            
            if (!string.IsNullOrEmpty(fileName) && check)
            {
                await video.Play(fileName);

                video.MediaItemFinished += (sender, args) =>
                {
                    FileHelper.DeleteFile(fileName);
                    fileName = null;
                };
            }
        }
        //public async Task Pause()
        //{
        //    var video = CrossMediaManager.Current;
        //    if (video.IsPlaying())
        //    {
        //        await video.Pause();
        //    }
        //}
        public async Task Leave()
        {
            var video = CrossMediaManager.Current;
            if (video.IsPlaying())
            {
                FileHelper.DeleteFile(fileName);
                await video.Stop();
            }
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
