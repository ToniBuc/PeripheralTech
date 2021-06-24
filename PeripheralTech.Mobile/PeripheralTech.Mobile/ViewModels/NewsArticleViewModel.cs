using PeripheralTech.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeripheralTech.Mobile.ViewModels
{
    public class NewsArticleViewModel : BaseViewModel
    {
        private readonly APIService _newsService = new APIService("News");
        public int? NewsID { get; set; }
        public NewsArticleViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public News News { get; set; }
        public ICommand InitCommand { get; set; }

        #region Initialization
        private string _newsTitle = string.Empty;
        public string NewsTitle
        {
            get { return _newsTitle; }
            set { SetProperty(ref _newsTitle, value); }
        }
        private string _authorTitle = string.Empty;
        public string AuthorTitle
        {
            get { return _authorTitle; }
            set { SetProperty(ref _authorTitle, value); }
        }
        private string _dateString = string.Empty;
        public string DateString
        {
            get { return _dateString; }
            set { SetProperty(ref _dateString, value); }
        }
        private string _content = string.Empty;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }
        private byte[] _thumbnail = null;
        public byte[] Thumbnail
        {
            get { return _thumbnail; }
            set { SetProperty(ref _thumbnail, value); }
        }
        #endregion

        public async Task Init()
        {
            News = await _newsService.GetById<Model.News>(NewsID);
            
            if (News != null)
            {
                NewsTitle = News.Title;
                AuthorTitle = "Author: " + News.Author + " - " + News.Date.ToShortDateString();
                //DateString = News.Date.ToShortDateString();
                Content = News.Content;
                Thumbnail = News.Thumbnail;
            }
            
        }
    }
}
