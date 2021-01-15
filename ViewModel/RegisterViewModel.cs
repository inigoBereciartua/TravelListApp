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
        public string RepeatPassword { get; set; }
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
        public RegisterViewModel()
        {
            Email = "";
            Username = "";
            Password = "";
            RepeatPassword = "";
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
            ErrorMessage = "";
            SuccesMessage = "";
            if (Username == "" || Email == "" || Password == "" || RepeatPassword == "")
            {
                ErrorMessage = "Please complete all the fields";
            }else if (!Password.Equals(RepeatPassword))
            {
                ErrorMessage = "Passwords don't match";
            }
            else
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
                    Cookie cookie = cookies.GetCookies(new Uri("http://localhost:65177")).Cast<Cookie>().ToList().FirstOrDefault(e => e.Name == ".AspNetCore.Identity.Application");
                    Client.Instantiate(client);
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
}
