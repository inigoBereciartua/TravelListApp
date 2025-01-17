﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Command;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class AddItemsToTravelViewModel
    {
        // This might need to get the selected travel so that we can call it later to add the items

        public AddItemsToTravelCommand AddItemsToTravelCommand { get; set; }
        public ObservableCollection<Item> ItemsList { get; set; }
        public string _errormessage;
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

        private async Task<ObservableCollection<Item>> GetItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }


        public AddItemsToTravelViewModel()
        {
            AddItemsToTravelCommand = new AddItemsToTravelCommand(this);
            ErrorMessage = "";
            ItemsList = System.Threading.Tasks.Task.Run(() => GetItems()).Result;
        }

        internal void AddItems()
        {
            throw new NotImplementedException();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
