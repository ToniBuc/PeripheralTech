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
    public class ProfileViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("User");
        private readonly APIService _cityService = new APIService("City");
        private readonly APIService _userRoleService = new APIService("UserRole");
        public ProfileViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SaveCommand = new Command(async () => await Save());
        }

        public ObservableCollection<City> CityList { get; set; } = new ObservableCollection<City>();

        private City _selectedCity;
        public City SelectedCity
        {
            get { return _selectedCity; }
            set { SetProperty(ref _selectedCity, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        #region Profile Initialization
        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private byte[] _image = null;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }
        #endregion

        public async Task Init()
        {
            var user = await _userService.GetById<Model.User>(APIService.UserID);

            var cityList = await _cityService.Get<List<City>>(null);
            if (CityList.Count == 0)
            {
                foreach (var x in cityList)
                {
                    CityList.Add(x);
                    if (user.CityID.HasValue)
                    {
                        if (user.City.Name == x.Name)
                        {
                            SelectedCity = x;
                        }
                    }
                    //else
                    //{
                    //    SelectedCity.CountryID = 0;
                    //    SelectedCity.CityID = 0;
                    //    SelectedCity.Name = "Unassigned";
                    //}
                }
            }

            if (user != null)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                Email = user.Email;
                PhoneNumber = user.PhoneNumber;
                Address = user.Address;
                Username = user.Username;
                var str = System.Text.Encoding.Default.GetString(user.ProfileImage);
                if (str != "")
                {
                    Image = user.ProfileImage;
                }

            }

        }

        public async Task Save()
        {
            var request = new UserUpdateRequest()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address,
                //CityID = SelectedCity.CityID,
                Username = Username
            };

            if (SelectedCity == null)
            {
                request.CityID = 0;
            }
            else
            {
                request.CityID = SelectedCity.CityID;
            }

            var userRoleList = await _userRoleService.Get<List<UserRole>>(null);
            int userRoleId = 0;
            foreach (var x in userRoleList)
            {
                if (x.Name == APIService.Role)
                {
                    userRoleId = x.UserRoleID;
                }
            }

            request.UserRoleID = userRoleId;

            try
            {
                await _userService.Update<Model.User>(APIService.UserID, request);
                await Application.Current.MainPage.DisplayAlert("Notification", "You have successfully updated your personal information!", "OK");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "There was an error during the updating process of your personal information, please make sure you have entered all the required information correctly.", "OK");
            }
        }
    }
}
