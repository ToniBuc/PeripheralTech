using Flurl.Http;
using PeripheralTech.Model;
using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PeripheralTech.Mobile
{
    public class APIService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string Role { get; set; }
        public static int UserID { get; set; }
        public static User User { get; set; }
        public static List<Product> ShoppingCart { get; set; }
        private string _route = null;
        public APIService(string route)
        {
            _route = route;
        }

#if DEBUG
        private string _apiUrl = "http://localhost:52508/api";
        //for android emulator:
        //private string _apiUrl = "http://10.0.2.2:52508/api";
#endif
#if RELEASE
        private string _apiUrl = "https://mywebsite.com/api";
#endif

        public async Task<T> Get<T>(object search)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> GetById<T>(object id)
        {

            var url = $"{_apiUrl}/{_route}/{id}";

            var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> GetStaff<T>(object search)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/GetStaff";

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                var result = await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                var result = await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }

        public async Task<T> Login<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            var result = await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

        public async Task<bool> Delete<T>(int id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return false;
            }
        }

        public async Task<T> Register<T>(UserInsertRequest request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}";

                var result = await url.PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                await Application.Current.MainPage.DisplayAlert("Error", stringBuilder.ToString(), "OK");
                return default(T);
            }
        }
    }
}
