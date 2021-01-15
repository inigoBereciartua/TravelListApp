using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Command;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
   public class RegisterViewModel: INotifyPropertyChanged
    {
        
        public  RegisterCommand RegisterCommand { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private string _succesmessage;
        public string SuccesMessage 
        { 
            get { return _succesmessage; } 
            set {
                if(value != _succesmessage)
                {
                    _succesmessage = value;
                    NotifyPropertyChanged("SuccesMessage");
                }
            }
        }
        public string ErrorMessage { get; set; }
        public RegisterViewModel()
        {
            Email = "FuckOff@gmail.com";
            Username = "FuckOff";
            Password = "FuckOff@123";
            ErrorMessage = "";
            SuccesMessage = "";
            RegisterCommand = new RegisterCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        internal async void Register()
        {
            var values = new Dictionary<string, string>
            {
                { "Username", Username },
                { "Password", Password },
                { "Email", Email },
            };

            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            var content = new FormUrlEncodedContent(values);
            HttpClient client = new HttpClient(handler);
            var result = await client.PostAsync("http://localhost:65177/api/User/register", content);
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["Cookie"] = JsonConvert.SerializeObject(cookies.GetCookies(new Uri("http://localhost:65177")).Cast<Cookie>().ToList().FirstOrDefault(e => e.Name == ".AspNetCore.Identity.Application"));
                /*Cookie cookie = JsonConvert.DeserializeObject<Cookie>(Windows.Storage.ApplicationData.Current.LocalSettings.Values["Cookie"].ToString());
                   CookieContainer cookies = new CookieContainer();
                 * cookies.Add(cookie);
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = cookies;
                var content = new FormUrlEncodedContent(values);
                HttpClient client = new HttpClient(handler);*/

                SuccesMessage = "You sucessfuly registered in !";
            }
            else if(result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                ErrorMessage = "Sorry our server is not working !";
            }
            else
            {
                ErrorMessage = "404";
            }
        }
    }
}
