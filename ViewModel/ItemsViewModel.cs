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
        public CreateItemCommand CreateItemCommand { get; set; }
        public RemoveItemCommand RemoveItemCommand { get; set; }
        public ObservableCollection<Item> ItemsList { get; set; }
        public string NewItemName { get; set; }
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
                    { "Description", NewItemName}                    
                };
                var content = new FormUrlEncodedContent(values);                
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Item", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    ItemsList.Add(new Item() { Name = NewItemName });                    
                }
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

        internal async void RemoveItem(Item selectedItem)
        {
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Item/" + selectedItem.Id.ToString());
            if (result.IsSuccessStatusCode)
            {
                ItemsList.Remove(selectedItem);
                //TODO Call Backend
            }
        }
    }
}
