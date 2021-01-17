using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Command;
using TravelListApp.Views;
using Windows.UI.Xaml;

namespace TravelListApp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginCommand LoginCommand { get; set; }

        private string _errormessage;
        public string ErrorMessage {
            get { return _errormessage; }
            set
            {
                if (value != _errormessage)
                {
                    _errormessage = value;
                    NotifyPropertyChanged("ErrorMessage");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LoginViewModel(){
            this.Username = "Clark_Kent";
            this.Password = "P@ssword1";
            this.ErrorMessage = "";            
            LoginCommand = new LoginCommand(this);
        }

        internal async Task<bool> Login()
        {
            ErrorMessage = "";            
            if (Username == "" || Password == "" )
            {
                ErrorMessage = "Please complete all the fields";
            }           
            else
            {
                var values = new Dictionary<string, string>
                {
                    { "Username", Username },
                    { "Password", Password },                    
                };

                CookieContainer cookies = new CookieContainer();
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = cookies;
                var content = new FormUrlEncodedContent(values);
                HttpClient client = new HttpClient(handler);
                var result = await client.PostAsync("http://localhost:65177/api/User/login", content);
                
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Cookie cookie= cookies.GetCookies(new Uri("http://localhost:65177")).Cast<Cookie>().ToList().FirstOrDefault(e => e.Name == ".AspNetCore.Identity.Application");                    
                    Client.Instantiate(client);                                        
                    return true;
                }
                else if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    ErrorMessage = "Sorry our server is not working !";
                }
                else
                {
                    ErrorMessage = "404";
                }
            }
                return false;
        }
    }
}
