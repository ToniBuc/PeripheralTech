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
    public class NewsViewModel : BaseViewModel
    {
        private readonly APIService _newsService = new APIService("News"); 
        public NewsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<News> NewsList { get; set; } = new ObservableCollection<News>();
        public ICommand InitCommand { get; set; }

        private string _searchText = null;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }

        }

        public async Task Init()
        {
            var newsList = await _newsService.Get<List<Model.News>>(null);
            NewsList.Clear();
            if (_searchText != null)
            {
                var normalizedQuery = _searchText?.ToLower() ?? "";
                foreach (var x in newsList)
                {
                    if (x.Title.ToLowerInvariant().Contains(normalizedQuery))
                    {
                        NewsList.Add(x);
                    }
                }
            }
            else
            {
                foreach (var x in newsList)
                {
                    NewsList.Add(x);
                }
            }
        }
    }
}
