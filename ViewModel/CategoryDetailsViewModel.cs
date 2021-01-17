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
    class CategoryDetailsViewModel
    {
        // This might need to get the selected Category so that we can call it later to add the other things
        public AddItemToCategoryCommand AddItemToCategoryCommand { get; set; }
        public AddTaskToCategoryCommand AddTaskToCategoryCommand { get; set; }
        public ObservableCollection<Item> ItemList { get; set; }
        public ObservableCollection<Model.Task> TaskList { get; set; }
        public ObservableCollection<Item> CategoryItems { get; set; }
        public ObservableCollection<Model.Task> CategoryTasks { get; set; }

        public Category Category { get; set; }

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
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Item");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Task");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }

        public CategoryDetailsViewModel()
        {
            AddItemToCategoryCommand = new AddItemToCategoryCommand(this);
            AddTaskToCategoryCommand = new AddTaskToCategoryCommand(this);
            ErrorMessage = "";
            
        }

        internal void AddItemToCategory()
        {
            throw new NotImplementedException();
        }
        internal void AddTaskToCategory()
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            CategoryItems = new ObservableCollection<Item>(Category.Items); 
            CategoryTasks = new ObservableCollection<Model.Task>(Category.Tasks);
            ItemList = System.Threading.Tasks.Task.Run(() => GetItems()).Result;
            ItemList = new ObservableCollection<Item>(ItemList.Where(e => !Category.Items.Contains(e)).ToList());
            TaskList = System.Threading.Tasks.Task.Run(() => GetTasks()).Result;
            TaskList = new ObservableCollection<Model.Task>(TaskList.Where(e => !Category.Tasks.Contains(e)).ToList());
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
