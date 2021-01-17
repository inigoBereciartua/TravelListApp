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
        public Item SelectedItem;
        public Model.Task SelectedTask;
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
            //Remove the item from ItemList, Add item to CategoryItems and add Item to Category.Item on the backend
            var item = SelectedItem;
            CategoryItems.Add(item);
            ItemList.Remove(item);
            //TODO: Call to the backend so that the item is added to category

            //var values = new Dictionary<string, string>
            //    {
            //        { "categoryName", NewCategoryName}
            //    };
            //var content = new FormUrlEncodedContent(values);
            //var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Category", content);

            //if (result.StatusCode == HttpStatusCode.OK)
            //{
            //    CategoriesList.Add(new Category() { Name = NewCategoryName });
            //    CategoriesList = System.Threading.Tasks.Task.Run(() => GetCategories()).Result;
            //}

        }
        internal void AddTaskToCategory()
        {
            //Remove the task from TaskList, Add task to CategoryTasks and add Task to Category.Task on the backend
            CategoryTasks.Add(SelectedTask);
            TaskList.Remove(SelectedTask);            
            //TODO: Call to the backend so that the task is added to category

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
