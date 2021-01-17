using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Command;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class AddCategoriesToTravelViewModel
    {
        // This might need to get the selected travel so that we can call it later to add the categories
        public Category SelectedCategory { get; set; }
        public Travel Travel;
        public string Amount;
        public AddCategoriesToTravelCommand AddCategoriesToTravelCommand { get; set; }
        public ObservableCollection<Category> CategoryList { get; set; }
        public ObservableCollection<Category> TravelCategories { get; set; }
        public ObservableCollection<Item> ItemsList { get; set; }
        public ObservableCollection<Item> TravelItems { get; set; }
        public ObservableCollection<Model.Task> TaskList { get; set; }
        public ObservableCollection<Model.Task> TravelTasks { get; set; }
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
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Category>(JsonConvert.DeserializeObject<List<Category>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Category>> GetTravelCategorys()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Categories");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Category>(JsonConvert.DeserializeObject<List<Category>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Item>> GetCategoryItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category/" + SelectedCategory.id + "/Items");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Item>> GetTravelItems()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + Travel.id.ToString() + "/Items");
            var callRes = JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Item>(JsonConvert.DeserializeObject<List<Item>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetTravelTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Travel/" + Travel.id + "/Tasks");
            var callRes = JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }
        private async Task<ObservableCollection<Model.Task>> GetCategoryTasks()
        {
            var result = await Client.HttpClient.GetAsync("http://localhost:65177/api/Category/" + SelectedCategory.id.ToString() + "/Tasks");
            var callRes = JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync());
            return new ObservableCollection<Model.Task>(JsonConvert.DeserializeObject<List<Model.Task>>(await result.Content.ReadAsStringAsync()));
        }
        
        
        internal async Task<string> saveItemAsync(Item item)
        {
            // Remove item for view (ItemList), add it to the travel on the backend
            if (Amount == "")
            {
                return "Please fill in item's amount";
            }
            try
            {
                item.Count = int.Parse(Amount);
                item.Checked = false;
                if (item.Count < 1)
                {
                    return "The amount of the item must be a number higher than 0";
                }
                var values = new Dictionary<string, string>
                {
                    { "TravelId", Travel.id.ToString() },
                    { "ItemId", item.Id.ToString() },
                    { "Count", Amount }
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Item", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    ItemsList.Remove(item);
                    if(ItemsList.Count == 0)
                    {
                        await SaveCategoryAndTasks();
                    }
                    return "";
                }
                return "An error occurred while adding item to travel";
            }
            catch (Exception e)
            {
                return "The amount of the item must be a number higher than 0";
            }
        }

        internal async Task<string> saveTaskAsync(Model.Task task)
        {
            if (task != null)
            {
                var values = new Dictionary<string, string>
                {
                    { "TravelId", Travel.id.ToString() },
                    { "TaskId", task.Id.ToString() },
                };
                var content = new FormUrlEncodedContent(values);
                var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Task", content);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    task.Checked = false;
                    return "";
                }
            }
            return "An error has occurred while adding the task to the travel";
        }

        internal async Task<string> saveCategoryAsync()
        {
            var values = new Dictionary<string, string>
            {
                { "TravelId", Travel.id.ToString() },
                { "CategoryId", SelectedCategory.id.ToString() },
            };

            var content = new FormUrlEncodedContent(values);
            var result = await Client.HttpClient.PostAsync("http://localhost:65177/api/Travel/Category", content);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                CategoryList.Remove(SelectedCategory);
                return "";
            }

            return "An error has occurred while adding the task to the travel";
        }

        internal async System.Threading.Tasks.Task SaveCategoryAndTasks()
        {            
            TaskList = System.Threading.Tasks.Task.Run(() => GetCategoryTasks()).Result;
            if(TaskList.Count > 0)
            {
                TravelTasks = System.Threading.Tasks.Task.Run(() => GetTravelTasks()).Result;
                TaskList = new ObservableCollection<Model.Task>(TaskList.Where(e => !TravelTasks.Contains(e)).ToList());
                foreach(Model.Task task in TaskList)
                {
                    await saveTaskAsync(task);
                }
            }

            await saveCategoryAsync();
            
        }

        public AddCategoriesToTravelViewModel()
        {
            AddCategoriesToTravelCommand = new AddCategoriesToTravelCommand(this);
            ErrorMessage = "";
            CategoryList = System.Threading.Tasks.Task.Run(() => GetCategorys()).Result;
        }

        internal void AddCategories()
        {
            if(SelectedCategory != null)
            {
                var list = System.Threading.Tasks.Task.Run(() => GetCategoryItems()).Result;
                TravelItems = System.Threading.Tasks.Task.Run(() => GetTravelItems()).Result;
                list = new ObservableCollection<Item>(list.Where(e => !TravelItems.Contains(e)).ToList());
                if(list.Count > 0)
                {
                    foreach(Item i in list)
                    {
                        ItemsList.Add(i);
                    }
                } else
                {
                    saveCategoryAsync();
                }
            }
        }

        public void LoadData()
        {
            CategoryList = System.Threading.Tasks.Task.Run(() => GetCategorys()).Result;
            TravelCategories = System.Threading.Tasks.Task.Run(() => GetTravelCategorys()).Result;
            TravelCategories = new ObservableCollection<Category>(TravelCategories.Where(e => !CategoryList.Contains(e)).ToList());
            ItemsList = new ObservableCollection<Item>();
            Console.WriteLine("");
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
