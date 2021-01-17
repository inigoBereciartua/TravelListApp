using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

        private async Task<ObservableCollection<Item>> GetCategoryItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category/" + Category.id + "/Items");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetCategoryTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category/" + Category.id + "/Tasks");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }


        public CategoryDetailsViewModel()
        {
            AddItemToCategoryCommand = new AddItemToCategoryCommand(this);
            AddTaskToCategoryCommand = new AddTaskToCategoryCommand(this);
            ErrorMessage = "";
            
        }

        internal async void AddItemToCategory()
        {
            //Remove the item from ItemList, Add item to CategoryItems and add Item to Category.Item on the backend
            if(SelectedItem != null)
            {
                var item = SelectedItem;

                var values = new Dictionary<string, string>
                    {
                        { "CategorylId", Category.id.ToString()},
                        { "ItemId", item.Id.ToString()}
                    };
                var content = new System.Net.Http.FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Category/Item", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    CategoryItems.Add(item);
                    ItemList.Remove(item);
                }
            }

        }

        internal async void AddTaskToCategory()
        {
            //Add task to CategoryTasks, Remove the task from TaskList and add Task to Category.Task on the backend
            
            if(SelectedTask != null)
            {
                var task = SelectedTask;
                var values = new Dictionary<string, string>
                    {
                        { "CategorylId", Category.id.ToString()},
                        { "TaskId", task.Id.ToString()}
                    };
                var content = new System.Net.Http.FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PutAsync("http://localhost:65177/api/Category/Task", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    CategoryTasks.Add(task);
                    TaskList.Remove(task);
                }
            }
        }

        internal async void RemoveItem(Item item)
        {
            //Add item to ItemList, remove item from CategoryItem and remove item from Category.Item on the backend
            

            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Category/" + Category.id.ToString() + "/Item/" + item.Id.ToString());
            if (result.IsSuccessStatusCode)
            {
                ItemList.Add((Item)item);
                CategoryItems.Remove((Item)item);
            }

        }
        internal async void RemoveTask(Model.Task task)
        {
            //Add task to TaskList, remove task from CategoryTask and remove task from Category.Task on the backend
            
            var result = await Client.HttpClient.DeleteAsync("http://localhost:65177/api/Category/" + Category.id.ToString() + "/Task/" + task.Id.ToString());
            if (result.IsSuccessStatusCode)
            {
                TaskList.Add((Model.Task)task);
            CategoryTasks.Remove((Model.Task)task);
            }
        }

        public void LoadData()
        {
            CategoryItems = System.Threading.Tasks.Task.Run(() => GetCategoryItems()).Result;
            CategoryTasks = System.Threading.Tasks.Task.Run(() => GetCategoryTasks()).Result;
            ItemList = System.Threading.Tasks.Task.Run(() => GetItems()).Result;
            ItemList = new ObservableCollection<Item>(ItemList.Where(e => !CategoryItems.Contains(e)).ToList());
            TaskList = System.Threading.Tasks.Task.Run(() => GetTasks()).Result;
            TaskList = new ObservableCollection<Model.Task>(TaskList.Where(e => !CategoryTasks.Contains(e)).ToList());
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
