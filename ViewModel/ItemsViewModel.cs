using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class ItemsViewModel
    {
        public CreateItemCommand CreateItemCommand;
        public RemoveItemCommand RemoveItemCommand;
        public ObservableCollection<Item> ItemsList { get; set; }
        public string NewItemName;
        private string _errormessage;
        public string ErrorMessage
        {
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

        public ItemsViewModel()
        {
            CreateItemCommand = new CreateItemCommand(this);
            RemoveItemCommand = new RemoveItemCommand(this);
            NewItemName = "";
            ItemsList = System.Threading.Tasks.Task.Run( ()=> GetItems()).Result;
        }

        private async Task<ObservableCollection<Item>> GetItems()
        {
            //HttpClient client = JsonConvert.DeserializeObject<HttpClient>(Windows.Storage.ApplicationData.Current.LocalSettings.Values["Client"].ToString());
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Item");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return  new ObservableCollection<Item>( JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));            
            
        }

        internal async void CreateItem()
        {            
            if (NewItemName == "")
            {
                ErrorMessage = "Please enter the new item's name";
            }else if (ItemNameIsInUse())
            {
                ErrorMessage = "That item name is already in use";
            }
            else
            {
                var values = new Dictionary<string, string>
                {
                    { "Name", NewItemName}                    
                };
                var content = new FormUrlEncodedContent(values);                
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Item", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    ItemsList.Add(new Item() { Name = NewItemName });
                    ItemsList = System.Threading.Tasks.Task.Run(()=> GetItems()).Result;
                }
            }            
        }
        internal async void DeleteItem(Item item)
        {                        
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Item/" + item.Id.ToString());
            if(result.StatusCode == HttpStatusCode.OK)
            {
                ItemsList.Remove(item);
            }

        }

        private bool ItemNameIsInUse()
        {
            foreach (var item in ItemsList)
            {
                if (item.Name == NewItemName)
                {
                    return true;
                }
            }
            return false;
        }

        internal void RemoveItem(Item selectedItem)
        {
            if(selectedItem != null)
            {
                Cookie cookie = JsonConvert.DeserializeObject<Cookie>(Windows.Storage.ApplicationData.Current.LocalSettings.Values["Cookie"].ToString());
                CookieContainer cookies = new CookieContainer();
                cookies.Add(cookie);
                HttpClientHandler handler = new HttpClientHandler();
                handler.CookieContainer = cookies;
                HttpClient client = new HttpClient(handler);
                //var result = await client.DeleteAsync("http://localhost:65177/api/Item");

            }
        }
    }
}
