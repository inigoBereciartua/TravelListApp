using Newtonsoft.Json;
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
    class AddCategoriesToTravelViewModel
    {
        // This might need to get the selected travel so that we can call it later to add the categories
        public AddCategoriesToTravelCommand AddCategoriesToTravelCommand { get; set; }
        public ObservableCollection<Category> CategoryList { get; set; }
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

        private async Task<ObservableCollection<Category>> GetCategorys()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Category>(JsonConvert.DeserializeObject<List<Category>>(await result.Content.ReadAsStringAsync()));
        }


        public AddCategoriesToTravelViewModel()
        {
            AddCategoriesToTravelCommand = new AddCategoriesToTravelCommand(this);
            ErrorMessage = "";
            CategoryList = System.Threading.Tasks.Task.Run(() => GetCategorys()).Result;
        }

        internal void AddCategories()
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
